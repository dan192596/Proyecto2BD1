using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Caja
    {
        public Caja()
        {
            LogMovimiento = new HashSet<LogMovimiento>();
        }

        public int Caja1 { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaAbre { get; set; }
        public DateTime? FechaCierra { get; set; }
        public decimal? Monto { get; set; }
        public int EmpleadoEmpleado { get; set; }
        public string MontoLetras { get; set; }
        public string Observacion { get; set; }

        public Empleado EmpleadoEmpleadoNavigation { get; set; }
        public ICollection<LogMovimiento> LogMovimiento { get; set; }
    }
}
