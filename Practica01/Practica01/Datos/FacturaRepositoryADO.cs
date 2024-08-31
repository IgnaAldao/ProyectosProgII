using Practica01.Datos.Utils;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        private SqlConnection _connection;

        public FacturaRepositoryADO()
        {
            _connection = new SqlConnection(Properties.Resources.cnnString);
        }
        public bool Add(Factura oFactura)
        {
            bool result = true;
            SqlTransaction? transaction = null;
            SqlConnection? connection = null;

            try
            {
                connection = DataHelper.Instance().GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_FACTURA", connection, transaction);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmd.Parameters.AddWithValue("@id_forma_pago", oFactura.FormaPago.Id);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);

                SqlParameter param = new SqlParameter("@NewFacturaId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int facturaId = (int)param.Value;

                foreach (var detalle in oFactura.Detalles)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE_FACTURA", connection, transaction);
                    cmdDetail.CommandType = CommandType.StoredProcedure;

                    cmdDetail.Parameters.AddWithValue("@factura_id", facturaId);
                    cmdDetail.Parameters.AddWithValue("@id_articulo", detalle.Articulo.Id);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    cmdDetail.ExecuteNonQuery();

                }

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                Console.WriteLine("Error al guardar la factura: " + ex.Message);
                result = false;
            }

            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }

        public bool Delete(int facturaId)
        {
            bool result = true;
            SqlTransaction? transaction = null;
            SqlConnection? connection = null;

            try
            {
                connection = DataHelper.Instance().GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                var cmdDeleteDetails = new SqlCommand("SP_ELIMINAR_DETALLES_POR_FACTURA", connection, transaction);
                cmdDeleteDetails.CommandType = CommandType.StoredProcedure;
                cmdDeleteDetails.Parameters.AddWithValue("@factura_id", facturaId);
                cmdDeleteDetails.ExecuteNonQuery();

                var cmdDeleteFactura = new SqlCommand("SP_ELIMINAR_FACTURA", connection, transaction);
                cmdDeleteFactura.CommandType = CommandType.StoredProcedure;
                cmdDeleteFactura.Parameters.AddWithValue("@factura_id", facturaId);
                cmdDeleteFactura.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                result = false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }

        public Factura Get(int numFactura)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@id_factura", numFactura));
            FormaPagoRepository formaPagoRepository = new FormaPagoRepository();
            DataTable t = DataHelper.Instance().ExecuteSPQuery("SP_RECUPERAR_FACTURA_POR_ID", parameters);

            if (t != null)
            {
                DataRow row = t.Rows[0];
                int numeroFactura = Convert.ToInt32(row["nro_factura"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                int idformaPago = Convert.ToInt32(row["id_forma_pago"]);
                string cliente = row["cliente"].ToString();

                FormaPago formaPago = formaPagoRepository.GetById(idformaPago);
                Factura factura = new Factura()
                {
                    NumeroFactura = numeroFactura,
                    Fecha = fecha,
                    FormaPago = formaPago,
                    Cliente = cliente
                };
                return factura;
            }
            return null;
        }

        public List<Factura> GetAll()
        {
            List<Factura> list = new List<Factura>();
            FormaPagoRepository formaPagoRepository = new FormaPagoRepository();
            var helper = DataHelper.Instance();
            var t = helper.ExecuteSPQuery("SP_RECUPERAR_FACTURAS", null);
            foreach (DataRow row in t.Rows)
            {
                int numeroFactura = Convert.ToInt32(row["nro_factura"]);
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                int idformaPago = Convert.ToInt32(row["id_forma_pago"]);
                string cliente = row["cliente"].ToString();

                FormaPago formaPago = formaPagoRepository.GetById(idformaPago);

                Factura factura = new Factura()
                {
                    NumeroFactura = numeroFactura,
                    Fecha = fecha,
                    FormaPago = formaPago,
                    Cliente = cliente
                };
                list.Add(factura);
            }
            return list;

        }

        public bool Update(int facturaId, DateTime? nuevaFecha = null, int? nuevaFormaPagoId = null, string? nuevoCliente = null)
        {
            bool result = true;
            SqlTransaction? transaction = null;
            SqlConnection? connection = null;

            try
            {
                connection = DataHelper.Instance().GetConnection();
                connection.Open();
                transaction = connection.BeginTransaction();

                var cmdUpdateFactura = new SqlCommand("SP_ACTUALIZAR_FACTURA_SIMPLE", connection, transaction);
                cmdUpdateFactura.CommandType = CommandType.StoredProcedure;
                cmdUpdateFactura.Parameters.AddWithValue("@factura_id", facturaId);

                cmdUpdateFactura.Parameters.AddWithValue("@fecha", nuevaFecha.HasValue ? (object)nuevaFecha.Value : DBNull.Value);
                cmdUpdateFactura.Parameters.AddWithValue("@id_forma_pago", nuevaFormaPagoId.HasValue ? (object)nuevaFormaPagoId.Value : DBNull.Value);
                cmdUpdateFactura.Parameters.AddWithValue("@cliente", !string.IsNullOrEmpty(nuevoCliente) ? (object)nuevoCliente : DBNull.Value);

                cmdUpdateFactura.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                result = false;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return result;
        }

    }
}
