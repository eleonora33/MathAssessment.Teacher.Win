MathAssessment System
=====================

Simple manual for the UI and API endpoint

Overview
--------
MathAssessment is a small system for importing, evaluating and storing students' math tasks. It contains:
- MathAssessment.Teacher.Win — a WinForms UI used by teachers to load exam XML files, validate and preview parsed tasks, and save results to the database.
- MathAssessment.WebAPI — a WebAPI endpoint to import the same XML file programmatically.
- MathAssessment.MathEngine — expression evaluator used to compute correct answers and decide correctness.
- MathAssessment.Application / MathAssessment.Data — service and repository layers that convert preview rows to DB records.

High-level architecture
-----------------------
- UI (WinForms) or API receive an exam XML file.
- XmlImportService parses XML into DTOs (TeacherImportDto, StudentImportDto, ExamImportDto, TaskImportDto).
- MathExpressionProcessor evaluates expressions and decides whether a student's answer is correct.
- Preview data is stored in a DataTable and displayed in the UI for review.
- DatabaseImportService / ExamImportRepository persist exams and tasks into the database.

Prerequisites
-------------
- Windows
- Visual Studio (2017/2019/2022) with .NET Framework 4.8 workload
- SQL Server (or connection configured in the repository layer) if you intend to save imports to the DB

Building and running
--------------------
1. Open the solution in Visual Studio.
2. Restore NuGet packages and build the solution (targets .NET Framework 4.8).

Running the UI (Teacher import)
-------------------------------
1. Set the startup project to MathAssessment.Teacher.Win and run (F5).
2. In the application ribbon:
   - Click "Browse" and select an exam XML file.
   - Click "Process" to parse and evaluate tasks. The preview grid will populate with rows containing:
     - StudentCode, ExamCode, TaskCode
     - ExpressionText, StudentAnswerText
     - CorrectAnswer (computed), IsCorrect (true/false)
   - Review the preview. Rows are color-coded: correct (green) and wrong (red).
   - Click "Save" to persist results to the database.

Running the API
---------------
1. Set MathAssessment.WebAPI as the startup project and run (IIS Express) or deploy to your API host.
2. Endpoint:
   POST /api/exam/import/xml
   - Accepts a multipart/form-data request with the XML file as the first file content.
   - Returns an ImportResultDto JSON with counts for imported exams, tasks, correct/wrong/error counts.

Curl example
------------
curl -X POST "http://localhost:port/api/exam/import/xml" \
  -H "Content-Type: multipart/form-data" \
  -F "file=@path/to/exam.xml"

Notes / Behavior
----------------
- Expression evaluation is performed by MathExpressionProcessor. The engine attempts to handle problematic constructs such as division by zero by preprocessing expressions. If evaluation fails for a task, the UI/API will show an ErrorMessage for that task and mark it as error (not saved as a correct/wrong task). The preview allows you to review and fix tasks before saving.
- The IsCorrect column is computed by comparing the student's parsed decimal answer to the evaluated correct answer (rounded to 2 decimals).

Troubleshooting
---------------
- If preview shows ErrorMessage for rows with division by zero, check MathExpressionProcessor.Evaluate and XML content. The engine includes logic to replace divisions by zero, but complex expressions may still fail to evaluate.
- If the app can't save to database, ensure connection string and DB are configured and accessible.
