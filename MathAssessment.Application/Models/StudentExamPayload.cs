using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.Teacher.Win.Models
{
    public sealed class StudentExamPayload
    {
        public string StudentCode { get; set; } = "";
        public string FullName { get; set; }
        public string ClassName { get; set; }

        public string ExamCode { get; set; } = "1";
        public List<TaskPayload> Tasks { get; set; } = new List<TaskPayload>();
    }
}
