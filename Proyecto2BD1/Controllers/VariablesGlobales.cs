using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto2BD1.Controllers
{
    public static class VariablesGlobales
    {

        public enum TipoUsuario
        {
            Empleado,
            Administrador
        }
        // read-write variable
        public static TipoUsuario Tipo { get; set; }//Si es maestro, estudiante o administrador
        public static string Empleado { get; set; }
        public static string Nombre { get; set; }

    }
}
