using MathAssessment.Data.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace MathAssessment.Application.Services
{
    public class StudentAnalyticsService
    {
        public DataTable GetStudentExams(string studentCode)
        {
            var ps = new[]
            {
                new SqlParameter("@StudentCode", SqlDbType.NVarChar, 50) { Value = studentCode }
            };

            var ds = DataHelper.ExecuteStoredProcedureDataSet("dbo.sp_GetStudentExams", ps);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        public DataTable GetExamDetails(long examId)
        {
            var ps = new[]
            {
                new SqlParameter("@ExamId", SqlDbType.BigInt) { Value = examId }
            };

            var ds = DataHelper.ExecuteStoredProcedureDataSet("dbo.sp_GetExamDetails", ps);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }
    }
}
