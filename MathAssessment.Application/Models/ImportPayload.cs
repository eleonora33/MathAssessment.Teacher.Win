using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.Teacher.Win.Models
{
    public sealed class ImportPayload
    {
        public string TeacherCode { get; set; } = "";
        public List<StudentExamPayload> Students { get; set; } = new List<StudentExamPayload>();
    }
}
