using Practico02_Back.Entities;
using Practico02_Back.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico02_Back.Data
{
    public class FacturaRepository : IFacturaRepository
    {
        public bool AddFactura(FacturaDTO factura)
        {
            bool aux = true;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@fecha", factura.Fecha));
                parameters.Add(new SqlParameter("@id_forma_pago", factura.FormaPago));
                parameters.Add(new SqlParameter("@cliente", factura.Cliente));
                DBHelper.GetInstance().ExecuteSQL("SP_INSERTAR_FACTURA", parameters);

            }
            catch (Exception)
            {
                aux = false;
            }
            return aux;
        }

        public List<Factura> GetFacturaFilter(DateTime? fecha, int? formaPago)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fecha", fecha));
            parameters.Add(new SqlParameter("@id_forma_pago", formaPago));
            DataTable dt = DBHelper.GetInstance().Consult("SP_RECUPERAR_FACTURAS_FILTER", parameters);
            List<Factura> lst = new List<Factura>();

            foreach (DataRow row in dt.Rows)
            {
                int nro = Convert.ToInt32(row["nro_factura"]);
                DateTime fec = (DateTime)row["fecha"];
                int formpag = (int)row["id_forma_pago"];
                string cliente = row["cliente"].ToString();

                Factura factura = new Factura()
                {
                    NroFactura = nro,
                    Fecha = fec,
                    FormaPago = formpag,
                    Cliente = cliente
                };
                lst.Add(factura);
            }
            return lst;
        }

        public List<Factura> GetFacturas()
        {
            DataTable dt = DBHelper.GetInstance().Consult("SP_RECUPERAR_FACTURAS");
            List<Factura> lst = new List<Factura>();

            foreach (DataRow row in dt.Rows)
            {
                int nro = Convert.ToInt32(row["nro_factura"]);
                DateTime fecha = (DateTime)row["fecha"];
                int formaPago= (int)row["id_forma_pago"];
                string cliente = row["cliente"].ToString();
                Factura factura = new Factura()
                {
                    NroFactura = nro,
                    Fecha = fecha,
                    FormaPago = formaPago,
                    Cliente = cliente
                };
                lst.Add(factura);
            }
            return lst;
        }

        public bool RemoveFactura(int nro)
        {
            bool aux = true;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@factura_id", nro));
                if (DBHelper.GetInstance().ExecuteSQL("SP_ELIMINAR_FACTURA", parameters) < 1)
                {
                    aux = false;
                }

            }
            catch (Exception)
            {
                aux = false;
            }
            return aux;
        }

        public bool UpdateFactura(Factura factura)
        {
            bool aux = true;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@nro_factura", factura.NroFactura));
                parameters.Add(new SqlParameter("@fecha", factura.Fecha));
                parameters.Add(new SqlParameter("@id_forma_pago", factura.FormaPago));
                parameters.Add(new SqlParameter("@cliente", factura.Cliente));
                if (DBHelper.GetInstance().ExecuteSQL("SP_UPDATE_FACTURA", parameters) < 1)
                    aux = false;
            }
            catch (Exception)
            {
                aux = false;
            }
            return aux;
        }
    }
}
