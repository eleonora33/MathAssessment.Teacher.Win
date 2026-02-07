using MathAssessment.App.DTOs;
using MathAssessment.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MathAssessment.App.Services
{
    public class DatabaseImportService
    {
        private readonly string connectionString;

        public DatabaseImportService()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["MathAssessmentDb"]
                .ConnectionString;
        }

        public ImportResultDto SaveImportResultToDatabase(TeacherImportDto teacherImport, DataTable previewTable)
        {
            if (teacherImport == null) throw new ArgumentNullException(nameof(teacherImport));
            if (previewTable == null) throw new ArgumentNullException(nameof(previewTable));
            if (previewTable.Rows.Count == 0) throw new InvalidOperationException("Preview table is empty.");

            long examImportId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int teacherId = UpsertTeacher(connection, teacherImport.TeacherCode, null, null);

                examImportId = CreateImport(connection, teacherId, Guid.NewGuid(), "ImportedFromUI.xml");

                SaveExamsAndTasks(connection, teacherId, examImportId, previewTable);
            }

            return BuildImportSummary(examImportId, previewTable);
        }

        private ImportResultDto BuildImportSummary(long importId, DataTable previewTable)
        {
            int tasksCount = previewTable.Rows.Count;
            int correctCount = 0;
            int wrongCount = 0;
            int errorCount = 0;
            int examsCount = 0;

            if (previewTable.Columns.Contains("StudentCode") && previewTable.Columns.Contains("ExamCode"))
            {
                var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (DataRow r in previewTable.Rows)
                {
                    string sc = Convert.ToString(r["StudentCode"]);
                    string ec = Convert.ToString(r["ExamCode"]);
                    set.Add($"{sc}||{ec}");
                }
                examsCount = set.Count;
            }

            foreach (DataRow r in previewTable.Rows)
            {
                string err = null;

                if (previewTable.Columns.Contains("ErrorMessage") && r["ErrorMessage"] != DBNull.Value)
                    err = Convert.ToString(r["ErrorMessage"]);

                if (!string.IsNullOrWhiteSpace(err))
                {
                    errorCount++;
                    continue;
                }

                bool isCorrect = false;
                if (previewTable.Columns.Contains("IsCorrect") && r["IsCorrect"] != DBNull.Value)
                    isCorrect = Convert.ToBoolean(r["IsCorrect"]);

                if (isCorrect) correctCount++;
                else wrongCount++;
            }

            return new ImportResultDto
            {
                ImportId = importId,
                ExamsCount = examsCount,
                TasksCount = tasksCount,
                CorrectCount = correctCount,
                WrongCount = wrongCount,
                ErrorCount = errorCount
            };
        }

        private int UpsertTeacher(SqlConnection connection, string teacherCode, string fullName, string email)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeacherCode", SqlDbType.NVarChar, 50) { Value = (object)teacherCode ?? DBNull.Value },
                new SqlParameter("@FullName", SqlDbType.NVarChar, 200) { Value = (object)fullName ?? DBNull.Value },
                new SqlParameter("@Email", SqlDbType.NVarChar, 200) { Value = (object)email ?? DBNull.Value },
                new SqlParameter("@TeacherId", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            ExecuteNonQuery(connection, "dbo.sp_UpsertTeacher", parameters);
            return Convert.ToInt32(parameters[3].Value);
        }

        private int UpsertStudent(SqlConnection connection, int teacherId, string studentCode, string fullName, string className)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeacherId", SqlDbType.Int) { Value = teacherId },
                new SqlParameter("@StudentCode", SqlDbType.NVarChar, 50) { Value = (object)studentCode ?? DBNull.Value },
                new SqlParameter("@FullName", SqlDbType.NVarChar, 200) { Value = (object)fullName ?? DBNull.Value },
                new SqlParameter("@ClassName", SqlDbType.NVarChar, 50) { Value = (object)className ?? DBNull.Value },
                new SqlParameter("@StudentId", SqlDbType.Int) { Direction = ParameterDirection.Output }
            };

            ExecuteNonQuery(connection, "dbo.sp_UpsertStudent", parameters);
            return Convert.ToInt32(parameters[4].Value);
        }

        private long CreateImport(SqlConnection connection, int teacherId, Guid importGuid, string sourceFileName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TeacherId", SqlDbType.Int) { Value = teacherId },
                new SqlParameter("@ImportGuid", SqlDbType.UniqueIdentifier) { Value = importGuid },
                new SqlParameter("@SourceFileName", SqlDbType.NVarChar, 260) { Value = (object)sourceFileName ?? DBNull.Value },
                new SqlParameter("@ExamImportId", SqlDbType.BigInt) { Direction = ParameterDirection.Output }
            };

            ExecuteNonQuery(connection, "dbo.sp_CreateImport", parameters);
            return Convert.ToInt64(parameters[3].Value);
        }

        private long CreateExam(SqlConnection connection, long examImportId, int teacherId, int studentId, string examCode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ExamImportId", SqlDbType.BigInt) { Value = examImportId },
                new SqlParameter("@TeacherId", SqlDbType.Int) { Value = teacherId },
                new SqlParameter("@StudentId", SqlDbType.Int) { Value = studentId },
                new SqlParameter("@ExamCode", SqlDbType.NVarChar, 50) { Value = (object)examCode ?? DBNull.Value },
                new SqlParameter("@ExamId", SqlDbType.BigInt) { Direction = ParameterDirection.Output }
            };

            ExecuteNonQuery(connection, "dbo.sp_CreateExam", parameters);
            return Convert.ToInt64(parameters[4].Value);
        }

        private void AddExamTask(
            SqlConnection connection,
            long examId,
            string taskCode,
            string originalText,
            string expressionText,
            string studentAnswerText,
            decimal? correctAnswer,
            bool isCorrect,
            string errorMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ExamId", SqlDbType.BigInt) { Value = examId },
                new SqlParameter("@TaskCode", SqlDbType.NVarChar, 50) { Value = (object)taskCode ?? DBNull.Value },
                new SqlParameter("@OriginalText", SqlDbType.NVarChar, 4000) { Value = (object)originalText ?? DBNull.Value },
                new SqlParameter("@ExpressionText", SqlDbType.NVarChar, 2000) { Value = (object)expressionText ?? DBNull.Value },
                new SqlParameter("@StudentAnswerText", SqlDbType.NVarChar, 2000) { Value = (object)studentAnswerText ?? DBNull.Value },
                new SqlParameter("@CorrectAnswer", SqlDbType.Decimal) { Precision = 18, Scale = 6, Value = (object)correctAnswer ?? DBNull.Value },
                new SqlParameter("@IsCorrect", SqlDbType.Bit) { Value = isCorrect },
                new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 2000) { Value = (object)errorMessage ?? DBNull.Value },
                new SqlParameter("@ExamTaskId", SqlDbType.BigInt) { Direction = ParameterDirection.Output }
            };

            ExecuteNonQuery(connection, "dbo.sp_AddExamTask", parameters);
        }

        private void RecalcExamSummary(SqlConnection connection, long examId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ExamId", SqlDbType.BigInt) { Value = examId }
            };

            ExecuteNonQuery(connection, "dbo.sp_RecalcExamSummary", parameters);
        }

        private void SaveExamsAndTasks(SqlConnection connection, int teacherId, long examImportId, DataTable previewTable)
        {
            var examKeyToExamId = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
            var studentCodeToStudentId = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (DataRow row in previewTable.Rows)
            {
                string studentCode = Convert.ToString(row["StudentCode"]);
                string examCode = Convert.ToString(row["ExamCode"]);
                string taskCode = Convert.ToString(row["TaskCode"]);
                string expressionText = Convert.ToString(row["ExpressionText"]);
                string studentAnswerText = Convert.ToString(row["StudentAnswerText"]);

                decimal? correctAnswer = row["CorrectAnswer"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["CorrectAnswer"]);
                bool isCorrect = row["IsCorrect"] != DBNull.Value && Convert.ToBoolean(row["IsCorrect"]);
                string errorMessage = row["ErrorMessage"] == DBNull.Value ? null : Convert.ToString(row["ErrorMessage"]);

                if (!studentCodeToStudentId.TryGetValue(studentCode, out int studentId))
                {
                    studentId = UpsertStudent(connection, teacherId, studentCode, null, null);
                    studentCodeToStudentId[studentCode] = studentId;
                }

                string examKey = $"{studentCode}||{examCode}";

                if (!examKeyToExamId.TryGetValue(examKey, out long examId))
                {
                    examId = CreateExam(connection, examImportId, teacherId, studentId, examCode);
                    examKeyToExamId[examKey] = examId;
                }

                string originalText = $"{expressionText} = {studentAnswerText}";

                AddExamTask(
                    connection,
                    examKeyToExamId[examKey],
                    taskCode,
                    originalText,
                    expressionText,
                    studentAnswerText,
                    correctAnswer,
                    isCorrect,
                    errorMessage
                );
            }

            foreach (var kvp in examKeyToExamId)
            {
                RecalcExamSummary(connection, kvp.Value);
            }
        }

        private void ExecuteNonQuery(SqlConnection connection, string procedureName, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 65;

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                command.ExecuteNonQuery();
            }
        }
    }
}
