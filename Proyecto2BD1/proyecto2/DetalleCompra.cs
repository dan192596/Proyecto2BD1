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
        public int Producto { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }
        public decimal? Subtotal { get; set; }
        public int? Cantidad { get; set; }
        public int Usuario { get; set; }
        public int Factura { get; set; }
        
        
        public int CompraCompra { get; set; }
        public int ProductoProducto { get; set; }
        public int ProveedorProveedor { get; set; }

        public Producto ProductoProductoNavigation { get; set; }
        public Compra CompraCompraNavigation { get; set; }
        public ICollection<Compra> Compra { get; set; }
    }
}
