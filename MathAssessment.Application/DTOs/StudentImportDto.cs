using MathAssessment.MathEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.App.DTOs
{
    public class StudentImportDto
    {
        public string StudentCode { get; set; }
        public IList<ExamImportDto> Exams { get; set; } = new List<ExamImportDto>();
    }
}
