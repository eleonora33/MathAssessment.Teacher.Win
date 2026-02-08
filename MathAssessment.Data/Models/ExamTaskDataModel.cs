namespace MathAssessment.Data.Models
{
    public class ExamTaskDataModel
    {
        public string StudentCode { get; set; }
        public string ExamCode { get; set; }
        public string TaskCode { get; set; }
        public string ExpressionText { get; set; }
        public string StudentAnswerText { get; set; }
        public decimal? CorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }
        public string ErrorMessage { get; set; }
    }
}