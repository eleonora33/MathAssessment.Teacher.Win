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
                var xmlImportService = new XmlImportService();
                var mathExpressionProcessor = new MathExpressionProcessor();

                teacherImport = xmlImportService.ParseTeacherXml(selectedXmlPath);

                previewDataTable = CreatePreviewDataTable();

                foreach (var student in teacherImport.Students)
                {
                    foreach (var exam in student.Exams)
                    {
                        foreach (var task in exam.Tasks)
                        {
                            bool isCorrect = false;
                            decimal correctAnswer = 0;
                            string errorMessage = null;

                            try
                            {
                                isCorrect = mathExpressionProcessor.IsCorrect(
                                    task.ExpressionText,
                                    task.StudentAnswerText,
                                    out correctAnswer
                                );
                            }
                            catch (Exception ex)
                            {
                                isCorrect = false;
                                correctAnswer = 0;
                                errorMessage = ex.Message;
                            }

                            DataTableHelper.AddRowToTable(
                                previewDataTable,
                                student.StudentCode,
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
                }

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
