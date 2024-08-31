using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos.Utils
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;

        public DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public static DataHelper Instance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable t = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (ParameterSQL param in parametros)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                t.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (Exception)
            {
                t = null;
            }
            return t;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
