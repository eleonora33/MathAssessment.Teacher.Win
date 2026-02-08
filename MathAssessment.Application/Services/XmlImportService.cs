using MathAssessment.App.DTOs;
using MathAssessment.MathEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MathAssessment.App.Services
{
    public class XmlImportService
    {
        public TeacherImportDto ParseTeacherXml(XDocument doc)
        {
            var teacherNode = doc.Root;
            if (teacherNode == null)
                return null;

            var teacher = new TeacherImportDto
            {
                TeacherCode = teacherNode.Attribute("ID")?.Value,
                Students = ParseStudents(teacherNode)
            };

            return teacher;
        }

        private List<StudentImportDto> ParseStudents(XElement teacherNode)
        {
            var studentNodes = teacherNode.Element("Students")?.Elements("Student");
            if (studentNodes == null)
                return new List<StudentImportDto>();

            return studentNodes.Select(studentNode => new StudentImportDto
            {
                StudentCode = studentNode.Attribute("ID")?.Value,
                Exams = ParseExams(studentNode)
            }).ToList();
        }

        private List<ExamImportDto> ParseExams(XElement studentNode)
        {
            return studentNode.Elements("Exam").Select(examNode => new ExamImportDto
            {
                ExamCode = examNode.Attribute("Id")?.Value,
                Tasks = ParseTasks(examNode)
            }).ToList();
        }

        private List<TaskImportDto> ParseTasks(XElement examNode)
        {
            return examNode.Elements("Task").Select(taskNode =>
            {
                var fullText = taskNode.Value;
                return new TaskImportDto
                {
                    TaskCode = taskNode.Attribute("id")?.Value,
                    OriginalText = fullText,
                    ExpressionText = ExtractExpression(fullText),
                    StudentAnswerText = ExtractStudentAnswer(fullText)
                };
            }).ToList();
        }

        private string ExtractExpression(string taskText)
        {
            var parts = taskText.Split('=');
            return parts.Length > 0 ? parts[0].Trim() : string.Empty;
        }

        private string ExtractStudentAnswer(string taskText)
        {
            var parts = taskText.Split('=');
            return parts.Length > 1 ? parts[parts.Length - 1].Trim() : string.Empty;
        }
    }
}
