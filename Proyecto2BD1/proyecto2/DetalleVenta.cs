using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class DetalleVenta
    {
        public int Detalle { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Subtotal { get; set; }
        public int FacturaVentaNoFactura { get; set; }
        public int ProductoProducto { get; set; }

        public Venta FacturaVentaNoFacturaNavigation { get; set; }
        public Producto ProductoProductoNavigation { get; set; }
    }
}
