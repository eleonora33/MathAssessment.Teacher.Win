using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.Application.DTOs
{
    public class TeacherImportDto
    {
        public string TeacherCode { get; set; }
        public IList<StudentImportDto> Students { get; set; } = new List<StudentImportDto>();
    }
}
