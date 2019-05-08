using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Producto
    {
        public Producto()
        {
            Descuento = new HashSet<Descuento>();
            DetalleCompra = new HashSet<DetalleCompra>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Producto1 { get; set; }
        public string Nombre { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? Existencia { get; set; }
        public decimal? PrecioCompra { get; set; }
        public int CategoriaCategoria { get; set; }

        public Categoria CategoriaCategoriaNavigation { get; set; }
        public ICollection<Descuento> Descuento { get; set; }
        public ICollection<DetalleCompra> DetalleCompra { get; set; }
        public ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
