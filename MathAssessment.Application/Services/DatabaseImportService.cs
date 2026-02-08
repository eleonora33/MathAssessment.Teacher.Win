using MathAssessment.Application.DTOs;
using MathAssessment.Application.DTOs;
using MathAssessment.Application.Utils.Constants;
using MathAssessment.Data.Models;
using MathAssessment.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace MathAssessment.Application.Services
{
    public class DatabaseImportService
    {
        private readonly ExamImportRepository repository;

        public DatabaseImportService()
        {
            repository = new ExamImportRepository();
        }

        public DatabaseImportService(ExamImportRepository repository)
        {
            this.repository = repository;
        }

        public ImportResultDto SaveImportResultToDatabase(TeacherImportDto teacherImport, DataTable previewTable, string source = IntegrationSource.ImportedFromUI)
        {
            if (teacherImport == null) throw new ArgumentNullException(nameof(teacherImport));
            if (previewTable == null) throw new ArgumentNullException(nameof(previewTable));
            if (previewTable.Rows.Count == 0) throw new InvalidOperationException("Preview table is empty.");

            int teacherId = repository.UpsertTeacher(teacherImport.TeacherCode, null, null);

            long examImportId = repository.CreateImport(teacherId, Guid.NewGuid(), source);

            var tasks = ConvertDataTableToTaskModels(previewTable);

            repository.SaveCompleteImport(teacherId, examImportId, tasks);

            return BuildImportSummary(examImportId, previewTable);
        }

        private List<ExamTaskDataModel> ConvertDataTableToTaskModels(DataTable previewTable)
        {
            var tasks = new List<ExamTaskDataModel>();

            foreach (DataRow row in previewTable.Rows)
            {
                tasks.Add(new ExamTaskDataModel
                {
                    StudentCode = Convert.ToString(row["StudentCode"]),
                    ExamCode = Convert.ToString(row["ExamCode"]),
                    TaskCode = Convert.ToString(row["TaskCode"]),
                    ExpressionText = Convert.ToString(row["ExpressionText"]),
                    StudentAnswerText = Convert.ToString(row["StudentAnswerText"]),
                    CorrectAnswer = row["CorrectAnswer"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["CorrectAnswer"]),
                    IsCorrect = row["IsCorrect"] != DBNull.Value && Convert.ToBoolean(row["IsCorrect"]),
                    ErrorMessage = row["ErrorMessage"] == DBNull.Value ? null : Convert.ToString(row["ErrorMessage"])
                });
            }

            return tasks;
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
    }
}
