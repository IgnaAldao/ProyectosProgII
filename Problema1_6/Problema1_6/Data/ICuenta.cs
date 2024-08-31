using Problema1_6.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_6.Data
{
    public interface ICuenta
    {
        bool Save(object o);
        bool Delete(object o);
        List<Cuenta> GetAll();
        bool AgregarCuenta(Cliente c, Cuenta cuenta);
        bool ExisteCliente(Cliente cliente);
    }
}
