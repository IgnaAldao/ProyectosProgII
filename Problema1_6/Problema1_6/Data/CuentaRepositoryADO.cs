using Problema1_6.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_6.Data
{
    internal class CuentaRepositoryADO : ICuenta
    {
        private SqlConnection _connection;
        public CuentaRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.connectionString);
        }
        public bool Delete(object o)
        {
            throw new NotImplementedException();
        }

        public List<Cuenta> GetAll()
        {
            List<Cuenta> list = new List<Cuenta>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_RECUPERAR_CUENTAS");
            foreach (DataRow row in t.Rows)
            {
                int cbu = Convert.ToInt32(row["cbu"].ToString());
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

        public bool Save(object o)
        {
            throw new NotImplementedException();
        }
        public bool AgregarCuenta(Cliente c, Cuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public bool ExisteCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
