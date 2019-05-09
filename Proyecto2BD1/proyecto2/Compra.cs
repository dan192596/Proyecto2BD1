using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Compra
    {
        public int NoFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }
        public int EmpleadoRegistro { get; set; }
        public int ProveedorProveedor { get; set; }
        //public int DetalleCompra { get; set; }

        //public DetalleCompra DetalleCompraNavigation { get; set; }
        public Proveedor ProveedorProveedorNavigation { get; set; }
    }
}
