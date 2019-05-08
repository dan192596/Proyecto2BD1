using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class LogMovimiento
    {
        public int Movimiento { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Hora { get; set; }
        public string Descripcion { get; set; }
        public decimal? Monto { get; set; }
        public int EmpleadoEmpleado { get; set; }
        public int CajaCaja { get; set; }
        public decimal? SaldoActual { get; set; }

        public Caja CajaCajaNavigation { get; set; }
        public Empleado EmpleadoEmpleadoNavigation { get; set; }
    }
}
