using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica01.Datos.Utils;

namespace Practica01.Datos
{
    public class FormaPagoRepository
    {
        public FormaPago GetById(int idFormaPago)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@id_forma_pago", idFormaPago));
            var helper = DataHelper.Instance();
            var t = helper.ExecuteSPQuery("SP_OBTENER_FORMA_PAGO_POR_ID", parameters);


            if (t.Rows.Count > 0)
            {
                DataRow row = t.Rows[0];
                return new FormaPago
                {
                    Nombre = row["nombre"].ToString()
                };
            }

            return null;
        }
    }

}
