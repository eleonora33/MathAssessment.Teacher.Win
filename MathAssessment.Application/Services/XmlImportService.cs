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
        public TeacherImportDto ParseTeacherXml(string xmlFilePath)
        {
            XDocument doc = XDocument.Load(xmlFilePath);

            XElement teacherNode = doc.Root;

            var teacher = new TeacherImportDto
            {
                TeacherCode = teacherNode.Attribute("ID")?.Value
            };

            var studentNodes = teacherNode.Element("Students")?.Elements("Student");

            if (studentNodes == null)
                return teacher;

            foreach (var studentNode in studentNodes)
            {
                var student = new StudentImportDto
                {
                    StudentCode = studentNode.Attribute("ID")?.Value
                };

                foreach (var examNode in studentNode.Elements("Exam"))
                {
                    var exam = new ExamImportDto
                    {
                        ExamCode = examNode.Attribute("Id")?.Value
                    };

                    foreach (var taskNode in examNode.Elements("Task"))
                    {
                        string fullText = taskNode.Value;

                        var task = new TaskImportDto
                        {
                            TaskCode = taskNode.Attribute("id")?.Value,
                            OriginalText = fullText,
                            ExpressionText = ExtractExpression(fullText),
                            StudentAnswerText = ExtractStudentAnswer(fullText)
                        };

                        exam.Tasks.Add(task);
                    }

                    student.Exams.Add(exam);
                }

                teacher.Students.Add(student);
            }

            return teacher;
        }

        private string ExtractExpression(string taskText)
        {
            return taskText.Split('=').First().Trim();
        }

        private string ExtractStudentAnswer(string taskText)
        {
            return taskText.Split('=').Last().Trim();
        }
    }
}
