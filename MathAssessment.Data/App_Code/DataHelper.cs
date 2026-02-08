using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MathAssessment.Data.App_Code
{
    public static class DataHelper
    {
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
    }
}
