using System;
using System.Data;
using System.Text.RegularExpressions;

namespace MathAssessment.MathEngine
{
    public class MathExpressionProcessor
    {
        public decimal Evaluate(string expression)
        {
            string fixedExpression = PreprocessExpression(expression);

            try
            {
                var table = new DataTable();
                object result = table.Compute(fixedExpression, string.Empty);
                return Convert.ToDecimal(result);
            }
            catch
            {
                throw new InvalidOperationException("Invalid mathematical expression.");
            }
        }

        private string PreprocessExpression(string expression)
        {
            var regex = new Regex(@"\(([^()]+)\)");

            int maxIterations = 10;
            int iteration = 0;

            while (regex.IsMatch(expression) && iteration < maxIterations)
            {
                expression = regex.Replace(expression, match =>
                {
                    string subExpr = match.Groups[1].Value;

                    try
                    {
                        var table = new DataTable();
                        object result = table.Compute(subExpr, string.Empty);
                        decimal value = Convert.ToDecimal(result);
                        return $"({value})";
                    }
                    catch
                    {
                        return match.Value;
                    }
                });

                iteration++;
            }

            expression = Regex.Replace(expression, @"/\s*\(\s*0(?:\.0*)?\s*\)", " * 0", RegexOptions.IgnoreCase);
            expression = Regex.Replace(expression, @"/\s*0(?:\.0*)?(?=\s|$|\)|\+|\-|\*|/)", " * 0", RegexOptions.IgnoreCase);

            return expression;
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
