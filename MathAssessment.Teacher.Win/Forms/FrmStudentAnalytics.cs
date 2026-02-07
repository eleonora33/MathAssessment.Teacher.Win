using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using MathAssessment.Application.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MathAssessment.Teacher.Win.Forms
{
    public partial class FrmStudentAnalytics : XtraForm
    {
        private readonly StudentAnalyticsService _service = new StudentAnalyticsService();

        public FrmStudentAnalytics()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitExamsGrid();
            InitTasksGrid();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var studentCode = txtStudentCode.Text?.Trim();

            if (string.IsNullOrWhiteSpace(studentCode))
            {
                XtraMessageBox.Show(
                    "Enter Student Code.",
                    "Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtStudentCode.Focus();
                return;
            }

            DataTable exams = _service.GetStudentExams(studentCode);

            gcExams.DataSource = exams;
            gcTasks.DataSource = null;

            gvExams.BestFitColumns();

            if (gvExams.RowCount > 0)
                gvExams.FocusedRowHandle = 0;
        }

        private void gvExams_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvExams.FocusedRowHandle < 0) return;

            DataRow row = gvExams.GetDataRow(gvExams.FocusedRowHandle);
            if (row == null) return;

            if (!row.Table.Columns.Contains("ExamId")) return;
            if (row["ExamId"] == DBNull.Value) return;

            long examId = Convert.ToInt64(row["ExamId"]);

            DataTable tasks = _service.GetExamDetails(examId);

            gcTasks.DataSource = tasks;

            gvTasks.BestFitColumns();
        }

        private void InitExamsGrid()
        {
            gvExams.OptionsBehavior.Editable = false;
            gvExams.OptionsBehavior.ReadOnly = true;
            gvExams.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvExams.OptionsView.ShowGroupPanel = false;
            gvExams.OptionsView.ColumnAutoWidth = false;
            gvExams.OptionsView.ShowFooter = true;

            gvExams.Columns.Clear();

            AddTextCol(gvExams, "ExamCode", "Exam", 0, 120);
            AddDateCol(gvExams, "ImportedAtUtc", "Imported", 1, 170, "dd.MM.yyyy HH:mm");
            AddIntCol(gvExams, "TotalTasks", "Total", 2, 70);
            AddIntCol(gvExams, "CorrectTasks", "Correct", 3, 80);
            AddPercentCol(gvExams, "ScorePercent", "Score %", 4, 80);

            HideCol(gvExams, "ExamId");
            HideCol(gvExams, "StudentCode");

            AddSummary(gvExams, "TotalTasks", SummaryItemType.Sum, "Σ {0}");
            AddSummary(gvExams, "CorrectTasks", SummaryItemType.Sum, "Σ {0}");
            AddSummary(gvExams, "ScorePercent", SummaryItemType.Average, "AVG {0:0.##}%");
        }

        private void InitTasksGrid()
        {
            gvTasks.OptionsBehavior.Editable = false;
            gvTasks.OptionsBehavior.ReadOnly = true;
            gvTasks.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvTasks.OptionsView.ShowGroupPanel = false;
            gvTasks.OptionsView.ColumnAutoWidth = false;
            gvTasks.OptionsView.ShowFooter = true;

            gvTasks.Columns.Clear();

            AddCenterTextCol(gvTasks, "TaskCode", "Task", 0, 70);
            AddTextCol(gvTasks, "ExpressionText", "Expression", 1, 190);
            AddTextCol(gvTasks, "StudentAnswerText", "Student Answer", 2, 150);
            AddTextCol(gvTasks, "CorrectAnswer", "Correct Answer", 3, 150);
            AddBoolCol(gvTasks, "IsCorrect", "OK", 4, 60);
            AddTextCol(gvTasks, "ErrorMessage", "Error", 5, 260);

            HideCol(gvTasks, "OriginalText");

            HideCol(gvTasks, "ExamId");
            HideCol(gvTasks, "ExamCode");
            HideCol(gvTasks, "ImportedAtUtc");
            HideCol(gvTasks, "TotalTasks");
            HideCol(gvTasks, "CorrectTasks");
            HideCol(gvTasks, "ScorePercent");

            ApplyCorrectWrongRowFormatting();

            AddSummary(gvTasks, "TaskCode", SummaryItemType.Count, "Tasks {0}");

            var colOk = gvTasks.Columns.ColumnByFieldName("IsCorrect");
            if (colOk != null)
            {
                colOk.Summary.Clear();
                colOk.Summary.Add(SummaryItemType.Custom).DisplayFormat = "OK {0}";
                gvTasks.CustomSummaryCalculate -= gvTasks_CustomSummaryCalculate;
                gvTasks.CustomSummaryCalculate += gvTasks_CustomSummaryCalculate;
            }
        }

        private void ApplyCorrectWrongRowFormatting()
        {
            gvTasks.FormatRules.Clear();

            var col = gvTasks.Columns.ColumnByFieldName("IsCorrect");
            if (col == null) return;

            var ruleCorrect = new GridFormatRule
            {
                ApplyToRow = true,
                Column = col,
                Name = "CorrectRow",
                Rule = new DevExpress.XtraEditors.FormatConditionRuleValue
                {
                    Condition = FormatCondition.Equal,
                    Value1 = true,
                    Appearance =
                    {
                        BackColor = Color.FromArgb(220, 245, 220),
                        Options = { UseBackColor = true }
                    }
                }
            };

            var ruleWrong = new GridFormatRule
            {
                ApplyToRow = true,
                Column = col,
                Name = "WrongRow",
                Rule = new FormatConditionRuleValue
                {
                    Condition = FormatCondition.Equal,
                    Value1 = false,
                    Appearance =
                    {
                        BackColor = Color.FromArgb(255, 230, 230),
                        Options = { UseBackColor = true }
                    }
                }
            };

            gvTasks.FormatRules.Add(ruleCorrect);
            gvTasks.FormatRules.Add(ruleWrong);
        }

        private void gvTasks_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (!(e.Item is GridSummaryItem item)) return;
            if (item.FieldName != "IsCorrect") return;

            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                e.TotalValue = 0;
            }
            else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                if (e.FieldValue != null && e.FieldValue != DBNull.Value && Convert.ToBoolean(e.FieldValue))
                    e.TotalValue = Convert.ToInt32(e.TotalValue) + 1;
            }
        }

        private static GridColumn AddTextCol(GridView view, string field, string caption, int index, int width)
        {
            var c = view.Columns.AddField(field);
            c.Caption = caption;
            c.VisibleIndex = index;
            c.Visible = true;
            c.Width = width;
            c.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            return c;
        }

        private static GridColumn AddCenterTextCol(GridView view, string field, string caption, int index, int width)
        {
            var c = AddTextCol(view, field, caption, index, width);
            c.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            return c;
        }

        private static GridColumn AddDateCol(GridView view, string field, string caption, int index, int width, string fmt)
        {
            var c = AddTextCol(view, field, caption, index, width);
            c.DisplayFormat.FormatType = FormatType.DateTime;
            c.DisplayFormat.FormatString = fmt;
            return c;
        }

        private static GridColumn AddIntCol(GridView view, string field, string caption, int index, int width)
        {
            var c = AddTextCol(view, field, caption, index, width);
            c.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            c.DisplayFormat.FormatType = FormatType.Numeric;
            c.DisplayFormat.FormatString = "0";
            return c;
        }

        private static GridColumn AddPercentCol(GridView view, string field, string caption, int index, int width)
        {
            var c = AddTextCol(view, field, caption, index, width);
            c.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            c.DisplayFormat.FormatType = FormatType.Custom;
            c.DisplayFormat.FormatString = "0.##'%'";
            return c;
        }

        private static GridColumn AddBoolCol(GridView view, string field, string caption, int index, int width)
        {
            var c = AddTextCol(view, field, caption, index, width);
            c.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            return c;
        }

        private static void HideCol(GridView view, string field)
        {
            var c = view.Columns.ColumnByFieldName(field);
            if (c != null) c.Visible = false;
        }

        private static void AddSummary(GridView view, string field, SummaryItemType type, string displayFormat)
        {
            var c = view.Columns.ColumnByFieldName(field);
            if (c == null) return;

            c.Summary.Add(type).DisplayFormat = displayFormat;
        }
    }
}
