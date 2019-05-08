using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class DetalleCompra
    {
        public DetalleCompra()
        {
            Compra = new HashSet<Compra>();
        }

        public int Detalle { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Subtotal { get; set; }
        public int ProductoProducto { get; set; }

        public Producto ProductoProductoNavigation { get; set; }
        public ICollection<Compra> Compra { get; set; }
    }
}
