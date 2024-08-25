using RepositoryExample.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryExample.Data
{
    public class ProductRepositoryADO : IProductoRepository
    {

        private SqlConnection _connection;

        public ProductRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_RECUPERAR_PRODUCTOS");
            foreach(DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["codigo"].ToString());
                string nombre = row["n_producto"].ToString();
                int stock = Convert.ToInt32(row["stock"].ToString());
                bool activo = Convert.ToBoolean(row["esta_activo"].ToString());

                Product oProduct = new Product() //es como si fuera un constructor con parametros
                {
                    Codigo = id,
                    Nombre = nombre,
                    Stock = stock,
                    Activo = activo
                };
                list.Add(oProduct);
            }

            return list;
        }
           
        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Product product)
        {
            bool result = true;            
            try
            {
                if(product != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand("SP_GUARDAR_PRODUCTO", _connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@codigo", product.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", product.Nombre);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);

                    result = cmd.ExecuteNonQuery() > 0; //cantidad de filas afectadas
                }
            }
            catch (SqlException sqlEx)
            {
                result = false;
            }
            finally //se ejecuta independientemente de que si se ejecuto o no
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }
    }
}
