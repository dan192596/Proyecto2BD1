using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Compra = new HashSet<Compra>();
        }

        public int Proveedor1 { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public ICollection<Compra> Compra { get; set; }
    }
}
