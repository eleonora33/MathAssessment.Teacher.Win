using System.Collections.Generic;

namespace MathAssessment.App.DTOs
{
    public class ExamImportDto
    {
        public string ExamCode { get; set; }
        public List<TaskImportDto> Tasks { get; set; } = new List<TaskImportDto>();
    }
}
