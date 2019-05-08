using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int Categoria1 { get; set; }
        public string Nombre { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
