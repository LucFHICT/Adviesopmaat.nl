using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AdviesOpMaatASP.NET.Classes;

namespace AdviesOpMaatASP.NET
{
    public class DBContext
    {
        public SqlConnection Connection { get; set; }

        public bool OpenConnection()
        {

            string connectionString = "Server=aomdb.database.windows.net;Database=dbi273302;User Id=luc;Password=T0w8rv6.;";

            Connection = new SqlConnection(connectionString);

            try
            {
                Connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                return false;
            }
        }
    }
}

