using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_6.Domain
{
    public class Cuenta
    {
        private int cbu;
        private int saldo;
        private TipoCuenta tipoCuenta;
        private string ultimoMovimiento;
        private int dniCliente;

        public int Cbu { get; set; }
        public int Saldo { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public string UltimoMovimiento { get; set; }
        public  int DniCliente { get; set; }

        public Cuenta()
        {
            
        }
    }
}
