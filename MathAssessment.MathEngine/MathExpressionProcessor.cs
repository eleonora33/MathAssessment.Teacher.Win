using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAssessment.MathEngine
{
    public class MathExpressionProcessor
    {
        public decimal Evaluate(string expression)
        {
            try
            {
                var table = new DataTable();
                object result = table.Compute(expression, string.Empty);
                return Convert.ToDecimal(result);
            }
            catch
            {
                throw new InvalidOperationException("Invalid mathematical expression.");
            }
        }

        public bool IsCorrect(string expression, string studentAnswer, out decimal correctAnswer)
        {
            correctAnswer = Evaluate(expression);

            if (!decimal.TryParse(studentAnswer, out decimal studentValue))
                return false;

            return Math.Round(studentValue, 2) == Math.Round(correctAnswer, 2);
        }
    }
}
