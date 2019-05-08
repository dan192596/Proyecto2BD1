using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Empleado
    {
        public Empleado()
        {
            Caja = new HashSet<Caja>();
            LogMovimiento = new HashSet<LogMovimiento>();
            Venta = new HashSet<Venta>();
        }

        public int Empleado1 { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

        public ICollection<Caja> Caja { get; set; }
        public ICollection<LogMovimiento> LogMovimiento { get; set; }
        public ICollection<Venta> Venta { get; set; }
    }
}
