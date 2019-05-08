using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Descuento
    {
        public int NoDescuento { get; set; }
        public int? Descuento1 { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int ProductoProducto { get; set; }

        public Producto ProductoProductoNavigation { get; set; }
    }
}
