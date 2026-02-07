using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.Application.DTOs
{
    public class ImportResultDto
    {
        public long ImportId { get; set; }
        public int ExamsCount { get; set; }
        public int TasksCount { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public int ErrorCount { get; set; }
    }
}
