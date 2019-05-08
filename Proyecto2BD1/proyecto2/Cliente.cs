using System;
using System.Collections.Generic;

namespace Proyecto2BD1.proyecto2
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Nit { get; set; }
        public string Nombre { get; set; }
        public string Dpi { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public ICollection<Venta> Venta { get; set; }
    }
}
