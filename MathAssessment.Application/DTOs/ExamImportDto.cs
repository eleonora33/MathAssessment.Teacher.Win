using System.Collections.Generic;

namespace MathAssessment.Application.DTOs
{
    public class ExamImportDto
    {
        public string ExamCode { get; set; }
        public List<TaskImportDto> Tasks { get; set; } = new List<TaskImportDto>();
    }
}
