using DevExpress.XtraEditors;
using MathAssessment.Application.DTOs;
using System;

namespace MathAssessment.Teacher.Win.Forms
{
    public partial class FrmImportResult : XtraForm
    {
        private readonly ImportResultDto _result;

        public FrmImportResult(ImportResultDto result)
        {
            InitializeComponent();
            _result = result ?? throw new ArgumentNullException(nameof(result));
        }

        private void FrmImportResult_Load(object sender, EventArgs e)
        {
            lblImportIdValue.Text = $"Import ID: {_result.ImportId}";
            lblExamsValue.Text = $"Exams: {_result.ExamsCount}";
            lblTasksValue.Text = $"Tasks: {_result.TasksCount}";
            lblCorrectValue.Text = $"Correct: {_result.CorrectCount}";
            lblWrongValue.Text = $"Wrong: {_result.WrongCount}";
            lblErrorsValue.Text = $"Errors: {_result.ErrorCount}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
