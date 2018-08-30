using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterViewCartV1.App_Start
{
    public class DbContext
    {
        private SqlDataAdapter _sqlDataAdapter;
        public SqlConnection Connection()
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection =new SqlConnection(connection);
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Open();
            }
            return sqlConnection;
        }

        public DataTable selectAll(SqlCommand sqlCommand)
        {
            _sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            _sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }


    }
}