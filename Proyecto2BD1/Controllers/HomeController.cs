using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Proyecto2BD1.Models;

namespace Proyecto2BD1.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration configuration;

        public object Enconding { get; private set; }

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                String usuario = "";
                String password = null;
                String rol = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "user":
                            usuario = item.Value;
                            break;
                        case "password":
                            password = item.Value;
                            break;
                        case "rol":
                            rol = item.Value;
                            break;
                    }
                }//LOGIN PARA TIPO DE USUARIO ADMINISTRADOR
                if (rol.Equals("administrador"))
                {
                    if (usuario == "bases1" && password == "123456789")
                    {
                        VariablesGlobales.Empleado = "0";
                        VariablesGlobales.Tipo = VariablesGlobales.TipoUsuario.Administrador;
                        VariablesGlobales.Nombre = "bases1";
                        return RedirectToAction("Index", "Administrador");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }//LOGIN PARA TIPO DE USUARIO MAESTRO
                else if (rol.Equals("empleado"))
                {
                    int ContadorFilas = 0;
                    List<String> ValoresUsuario = new List<string>();
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "login_empleado";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@empleado", MySqlDbType.Int16).Value = usuario;
                        cmd.Parameters.Add("@password", MySqlDbType.VarChar, 50).Value = password;
                        MySqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            ValoresUsuario.Add(sdr[0].ToString());//empleado
                            ValoresUsuario.Add(sdr[1].ToString());//nombre
                            ValoresUsuario.Add(sdr[2].ToString());//direccion
                            ValoresUsuario.Add(sdr[3].ToString());//telefono
                            ValoresUsuario.Add(sdr[4].ToString());//correo
                            ValoresUsuario.Add(sdr[5].ToString());//password
                            ContadorFilas++;
                        }
                    }
                    connection.Close();
                    if (ContadorFilas == 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        VariablesGlobales.Empleado = ValoresUsuario.ElementAt(0);
                        VariablesGlobales.Nombre = ValoresUsuario.ElementAt(1);
                        VariablesGlobales.Tipo = VariablesGlobales.TipoUsuario.Empleado;
                        return RedirectToAction("Index", "Administrador");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }


    }
}
