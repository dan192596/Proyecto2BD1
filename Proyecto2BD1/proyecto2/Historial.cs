using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Historial
    {
        public int Historial1 { get; set; }
        public DateTime? FechaEmision { get; set; }
        public decimal? TotalFactura { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? Abono { get; set; }
        public DateTime? FechaPago { get; set; }
        public int? Estado { get; set; }
        public int FacturaVentaNoFactura { get; set; }

        public Venta FacturaVentaNoFacturaNavigation { get; set; }
    }
}
