using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MathAssessment.Data.App_Code
{
    public static class DataHelper
    {
        public static int ExecuteWithOutputInt(string procedureName, SqlParameter[] parameters, string outputParamName)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MathAssessmentDb"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 65;

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.Parameters[outputParamName].Value);
            }
        }

        public static DataSet ExecuteStoredProcedureDataSet(string procedure, SqlParameter[] procedureParameters)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(procedure, ConfigurationManager.ConnectionStrings["MathAssessmentDb"].ConnectionString);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 65;

            if (procedureParameters != null)
                da.SelectCommand.Parameters.AddRange(procedureParameters);

            da.Fill(ds);
            return ds;
        }

        public static void ExecuteStoredProcedure(string procedureName, SqlParameter[] procedureParameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MathAssessmentDb"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 65;

                if (procedureParameters != null)
                    cmd.Parameters.AddRange(procedureParameters);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static long ExecuteWithOutputLong(string procedureName, SqlParameter[] parameters, string outputParamName)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MathAssessmentDb"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 65;

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToInt64(cmd.Parameters[outputParamName].Value);
            }
        }
    }
}
