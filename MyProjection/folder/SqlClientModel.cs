using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyProjection.folder
{
    public static class SqlClientModel
    {
        private static string _connectionString = @"Data source=WIN-5RSC18PG333\SQLEXPRESS; initial catalog=FinalDataBase; integrated security=true";
        public static SqlConnection GetNewSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
