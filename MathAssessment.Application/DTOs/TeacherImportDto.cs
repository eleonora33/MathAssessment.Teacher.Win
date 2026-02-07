using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.App.DTOs
{
    public class TeacherImportDto
    {
        public string TeacherCode { get; set; }
        public List<StudentImportDto> Students { get; set; } = new List<StudentImportDto>();
    }
}
