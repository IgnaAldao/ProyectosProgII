using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Data
{
    public class DBHelper
    {
        private static DBHelper instance = null;
        private SqlConnection connection = null;

        private DBHelper()
        {
            connection = new SqlConnection(@"Data Source=LAPTOP-9VR6P1V7;Initial Catalog=Practico01;Integrated Security=True;Encrypt=False");
        }

        public static DBHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new DBHelper();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public DataTable Consult(string nombreSP, List<SqlParameter>? parameters = null)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                }
            }

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            return dt;
        }

        public int ExecuteSQL(string nombreSP, List<SqlParameter>? parameters = null)
        {
            connection.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = connection;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            if (parameters != null)
            {
                foreach (var param in parameters)
                    comando.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            int result = comando.ExecuteNonQuery();
            connection.Close();
            return result;
        }


    }
}
