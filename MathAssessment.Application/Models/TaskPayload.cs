using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.Teacher.Win.Models
{
    public sealed class TaskPayload
    {
        public string TaskCode { get; set; } = "";
        public string OriginalText { get; set; } = "";

        public string ExpressionText { get; set; } = "";
        public string StudentAnswerText { get; set; } = "";
    }
}
