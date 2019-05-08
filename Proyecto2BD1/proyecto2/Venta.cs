using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
            Historial = new HashSet<Historial>();
        }

        public int NoFactura { get; set; }
        public string NombreCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }
        public decimal? Iva { get; set; }
        public int EmpleadoEmpleado { get; set; }
        public int ClienteNit { get; set; }

        public Cliente ClienteNitNavigation { get; set; }
        public Empleado EmpleadoEmpleadoNavigation { get; set; }
        public ICollection<DetalleVenta> DetalleVenta { get; set; }
        public ICollection<Historial> Historial { get; set; }
    }
}
