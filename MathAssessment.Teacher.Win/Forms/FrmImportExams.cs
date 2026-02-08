using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using MathAssessment.MathEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MathAssessment.App.DTOs;
using MathAssessment.App.Services;
using MathAssessment.Data.App_Code;
using System.Xml.Linq;

namespace MathAssessment.Teacher.Win.Forms
{
    public partial class FrmImportExams : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable previewDataTable;
        private TeacherImportDto teacherImport;
        private string selectedXmlPath;

        public FrmImportExams()
        {
            InitializeComponent();
        }

        private void FrmImportExams_Load(object sender, EventArgs e)
        {
            BindPreviewTableToGrid(previewDataTable);
        }

        private DataTable CreatePreviewDataTable()
        {
            Dictionary<string, Type> previewColumnDefinitions =
                new Dictionary<string, Type>
                {
                    { "StudentCode", typeof(string) },
                    { "ExamCode", typeof(string) },
                    { "TaskCode", typeof(string) },
                    { "ExpressionText", typeof(string) },
                    { "StudentAnswerText", typeof(string) },
                    { "CorrectAnswer", typeof(decimal) },
                    { "IsCorrect", typeof(bool) },
                    { "ErrorMessage", typeof(string) }
                };

            return DataTableHelper.CreateDataTable(previewColumnDefinitions);
        }

        private void BindPreviewTableToGrid(DataTable tableToShow)
        {
            gcPreview.DataSource = tableToShow;
        }

        private void btnBrowseXml_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "XML files (*.xml)|*.xml";
                dialog.Title = "Select exam XML file";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedXmlPath = dialog.FileName;

                    ribbonStatusBar.ItemLinks.Clear();
                    ribbonStatusBar.ItemLinks.Add(
                        new BarStaticItem
                        {
                            Caption = $"Loaded: {System.IO.Path.GetFileName(selectedXmlPath)}"
                        }
                    );
                }
            }
        }

        private void btnProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedXmlPath))
            {
                XtraMessageBox.Show(
                    "Please select an XML file first.",
                    "Missing XML",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                if (!TryValidateXml(selectedXmlPath, out XDocument doc))
                {
                    return;
                }

                var xmlImportService = new XmlImportService();
                var mathExpressionProcessor = new MathExpressionProcessor();

                teacherImport = xmlImportService.ParseTeacherXml(doc);

                previewDataTable = CreatePreviewDataTable();

                PopulatePreviewTable(teacherImport, mathExpressionProcessor, previewDataTable);

                gcPreview.DataSource = previewDataTable;

                btnSave.Enabled = previewDataTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    "Import error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void PopulatePreviewTable(
            TeacherImportDto teacherImport,
            MathExpressionProcessor mathProcessor,
            DataTable previewTable)
        {
            foreach (var student in teacherImport.Students)
            {
                foreach (var exam in student.Exams)
                {
                    ProcessExamTasks(student.StudentCode, exam, mathProcessor, previewTable);
                }
            }
        }

        private void ProcessExamTasks(
            string studentCode,
            ExamImportDto exam,
            MathExpressionProcessor mathProcessor,
            DataTable previewTable)
        {
            foreach (var task in exam.Tasks)
            {
                var (isCorrect, correctAnswer, errorMessage) = EvaluateTask(task, mathProcessor);

                DataTableHelper.AddRowToTable(
                    previewTable,
                    studentCode,
                    exam.ExamCode,
                    task.TaskCode,
                    task.ExpressionText,
                    task.StudentAnswerText,
                    correctAnswer,
                    isCorrect,
                    errorMessage
                );
            }
        }

        private (bool isCorrect, decimal correctAnswer, string errorMessage) EvaluateTask(
            TaskImportDto task,
            MathExpressionProcessor mathProcessor)
        {
            try
            {
                bool isCorrect = mathProcessor.IsCorrect(
                    task.ExpressionText,
                    task.StudentAnswerText,
                    out decimal correctAnswer
                );

                return (isCorrect, correctAnswer, null);
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }

        private bool TryValidateXml(string xmlPath, out XDocument doc)
        {
            doc = null;

            try
            {
                doc = XDocument.Load(xmlPath);
            }
            catch (System.Xml.XmlException xex)
            {
                XtraMessageBox.Show(
                    $"The selected file is not a valid XML file:\n{xex.Message}",
                    "Invalid XML",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Unable to load the XML file:\n{ex.Message}",
                    "File load error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            if (doc.Root == null)
            {
                XtraMessageBox.Show(
                    "The XML file does not contain a root element.",
                    "Invalid XML Structure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            if (!string.Equals(doc.Root.Name.LocalName, "Teacher", StringComparison.OrdinalIgnoreCase))
            {
                XtraMessageBox.Show(
                    "The XML file does not appear to be in the expected format. Expected root element 'Teacher'.",
                    "Invalid XML Structure",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (previewDataTable == null || previewDataTable.Rows.Count == 0)
            {
                XtraMessageBox.Show(
                    "Nothing to save. Please process an XML first.",
                    "No data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var confirm = XtraMessageBox.Show(
                "Are you sure you want to save the imported results?",
                "Confirm Save",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            var dbService = new DatabaseImportService();
            var result = dbService.SaveImportResultToDatabase(teacherImport, previewDataTable);

            using (var frm = new FrmImportResult(result))
            {
                frm.ShowDialog();
            }
        }
    }
}
