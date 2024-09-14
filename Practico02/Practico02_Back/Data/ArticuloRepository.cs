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
    public class ArticuloRepository : IArticuloRepository
    {
        public bool AddArticulo(ArticuloDTO articulo)
        {
            bool aux = true;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@nombre", articulo.Nombre));
                parameters.Add(new SqlParameter("@precio", articulo.PrecioUnitario));
                DBHelper.GetInstance().ExecuteSQL("SP_INSERTAR_ARTICULO", parameters);

            }catch (Exception )
            {
                aux= false;
            }
            return aux;
        }

        public List<Articulo> GetArticulos()
        {
            DataTable dt = DBHelper.GetInstance().Consult("SP_OBTENER_ARTICULOS");
            List<Articulo> lst = new List<Articulo>();

            foreach(DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_articulo"]);
                string nombre = row["nombre"].ToString();
                float precio = Convert.ToSingle(row["precio_unitario"]);
                Articulo articulo = new Articulo()
                {
                    Id = id,
                    Nombre = nombre,
                    PrecioUnitario = precio,
                };
                lst.Add(articulo);
            }
            return lst;
        }

        public bool RemoveArticulo(int id)
        {
            bool aux = true;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("id_articulo", id));
                if(DBHelper.GetInstance().ExecuteSQL("SP_ELIMINAR_ARTICULO", parameters) < 1)
                {
                    aux = false;
                }
                    
            }
                catch (Exception)
            {
                aux= false;
            }
            return aux;
        }

        public bool UpdateArticulo(Articulo articulo)
        {
            bool aux = true;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@id_articulo", articulo.Id));
                parameters.Add(new SqlParameter("@nombre", articulo.Nombre));
                parameters.Add(new SqlParameter("@precio", articulo.PrecioUnitario));
                if(DBHelper.GetInstance().ExecuteSQL("SP_UPDATE_ARTICULO", parameters) < 1)
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
