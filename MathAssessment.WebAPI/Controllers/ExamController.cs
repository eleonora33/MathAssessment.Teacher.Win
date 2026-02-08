using MathAssessment.Application.DTOs;
using MathAssessment.Application.Services;
using MathAssessment.Application.Utils.Constants;
using MathAssessment.Data.App_Code;
using MathAssessment.MathEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;

namespace MathAssessment.WebAPI.Controllers
{
    [RoutePrefix("api/exam")]
    public class ExamController : ApiController
    {
        private readonly DatabaseImportService importService;
        private readonly XmlImportService xmlImportService;

        public ExamController()
        {
            importService = new DatabaseImportService();
            xmlImportService = new XmlImportService();
        }

        [HttpPost]
        [Route("import/xml")]
        public async Task<IHttpActionResult> ImportFromXmlFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest("Unsupported media type. Please upload a file using multipart/form-data.");
            }

            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                if (provider.Contents.Count == 0)
                {
                    return BadRequest("No file uploaded");
                }

                var fileContent = provider.Contents[0];
                var fileBytes = await fileContent.ReadAsByteArrayAsync();
                var xmlContent = System.Text.Encoding.UTF8.GetString(fileBytes);

                if (string.IsNullOrWhiteSpace(xmlContent))
                {
                    return BadRequest("XML file is empty");
                }

                XDocument doc = XDocument.Parse(xmlContent);
                var teacherImport = xmlImportService.ParseTeacherXml(doc);
                DataTable previewDataTable = CreatePreviewDataTable();
                PopulatePreviewTable(teacherImport, new MathExpressionProcessor(), previewDataTable);

                var result = importService.SaveImportResultToDatabase(
                    teacherImport,
                    previewDataTable,
                    IntegrationSource.ImportedFromAPI
                );

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private DataTable CreatePreviewDataTable()
        {
            Dictionary<string, Type> previewColumnDefinitions =
                new Dictionary<string, Type>
                {
                    { "StudentCode", typeof(string) },
                    { "ExamCode", typeof(string) },
                    { "TaskCode", typeof(string) },
                    { "ExpressionText", typeof(string) },
                    { "StudentAnswerText", typeof(string) },
                    { "CorrectAnswer", typeof(decimal) },
                    { "IsCorrect", typeof(bool) },
                    { "ErrorMessage", typeof(string) }
                };

            return DataTableHelper.CreateDataTable(previewColumnDefinitions);
        }

        private void PopulatePreviewTable(
            TeacherImportDto teacherImport,
            MathExpressionProcessor mathProcessor,
            DataTable previewTable)
        {
            foreach (var student in teacherImport.Students)
            {
                foreach (var exam in student.Exams)
                {
                    ProcessExamTasks(student.StudentCode, exam, mathProcessor, previewTable);
                }
            }
        }

        private void ProcessExamTasks(
            string studentCode,
            ExamImportDto exam,
            MathExpressionProcessor mathProcessor,
            DataTable previewTable)
        {
            foreach (var task in exam.Tasks)
            {
                var (isCorrect, correctAnswer, errorMessage) = EvaluateTask(task, mathProcessor);

                DataTableHelper.AddRowToTable(
                    previewTable,
                    studentCode,
                    exam.ExamCode,
                    task.TaskCode,
                    task.ExpressionText,
                    task.StudentAnswerText,
                    correctAnswer,
                    isCorrect,
                    errorMessage
                );
            }
        }

        private (bool isCorrect, decimal correctAnswer, string errorMessage) EvaluateTask(
            TaskImportDto task,
            MathExpressionProcessor mathProcessor)
        {
            try
            {
                bool isCorrect = mathProcessor.IsCorrect(
                    task.ExpressionText,
                    task.StudentAnswerText,
                    out decimal correctAnswer
                );

                return (isCorrect, correctAnswer, null);
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }
    }
}