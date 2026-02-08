using MathAssessment.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MathAssessment.Data.Repositories
{
    public class ExamImportRepository
    {
        private readonly string connectionString;

        public ExamImportRepository()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["MathAssessmentDb"]
                .ConnectionString;
        }

        public ExamImportRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int UpsertTeacher(string teacherCode, string fullName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return UpsertTeacher(connection, teacherCode, fullName, email);
            }
        }

        public int UpsertStudent(int teacherId, string studentCode, string fullName, string className)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return UpsertStudent(connection, teacherId, studentCode, fullName, className);
            }
        }

        public long CreateImport(int teacherId, Guid importGuid, string sourceFileName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return CreateImport(connection, teacherId, importGuid, sourceFileName);
            }
        }

        public long CreateExam(long examImportId, int teacherId, int studentId, string examCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return CreateExam(connection, examImportId, teacherId, studentId, examCode);
            }
        }

        public void AddExamTask(
            long examId,
            string taskCode,
            string originalText,
            string expressionText,
            string studentAnswerText,
            decimal? correctAnswer,
            bool isCorrect,
            string errorMessage)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                AddExamTask(connection, examId, taskCode, originalText, expressionText,
                    studentAnswerText, correctAnswer, isCorrect, errorMessage);
            }
        }

        public void RecalcExamSummary(long examId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                RecalcExamSummary(connection, examId);
            }
        }

        public void SaveCompleteImport(
            int teacherId,
            long examImportId,
            IEnumerable<ExamTaskDataModel> tasks)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SaveExamsAndTasks(connection, teacherId, examImportId, tasks);
            }
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

        private void SaveExamsAndTasks(SqlConnection connection, int teacherId, long examImportId, IEnumerable<ExamTaskDataModel> tasks)
        {
            var examKeyToExamId = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
            var studentCodeToStudentId = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var task in tasks)
            {
                if (!studentCodeToStudentId.TryGetValue(task.StudentCode, out int studentId))
                {
                    studentId = UpsertStudent(connection, teacherId, task.StudentCode, null, null);
                    studentCodeToStudentId[task.StudentCode] = studentId;
                }

                string examKey = $"{task.StudentCode}||{task.ExamCode}";

                if (!examKeyToExamId.TryGetValue(examKey, out long examId))
                {
                    examId = CreateExam(connection, examImportId, teacherId, studentId, task.ExamCode);
                    examKeyToExamId[examKey] = examId;
                }

                string originalText = $"{task.ExpressionText} = {task.StudentAnswerText}";

                AddExamTask(
                    connection,
                    examKeyToExamId[examKey],
                    task.TaskCode,
                    originalText,
                    task.ExpressionText,
                    task.StudentAnswerText,
                    task.CorrectAnswer,
                    task.IsCorrect,
                    task.ErrorMessage
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
