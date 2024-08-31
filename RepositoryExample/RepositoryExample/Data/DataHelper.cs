using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public  class DataHelper
    {
        private static DataHelper _instancia;
        private SqlConnection _connection;


        private DataHelper() 
        { 
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }

        public static DataHelper GetInstance() //estatico porque es propio de la clase
                                               //esto es un ejmeplo del patron singleton
        {
            if (_instancia == null)
            {
                _instancia = new DataHelper();
            }
            return _instancia;
        }

        public DataTable ExecuteSPQuery(string sp)
        {

            DataTable t = new DataTable();
            try
            {

                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                t.Load(cmd.ExecuteReader());
                _connection.Close();
            }
            catch (Exception)
            {
                t = null;
            }
            return t;
        }

        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }

            return rows;
        }

    }
}
