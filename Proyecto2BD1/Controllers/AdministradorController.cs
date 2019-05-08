using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Proyecto2BD1.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly IConfiguration configuration;
        public AdministradorController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Administrador
        public ActionResult Index()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM empleado", connection);
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[0].ToString());//Id
                numb.Add(sdr[1].ToString());//Nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                String empleado = "";
                String nombre = "";
                String direccion = "";
                String telefono = "";
                String correo = "";
                String password = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "empleado1":
                            empleado = item.Value;
                            break;
                        case "nombre":
                            nombre = item.Value;
                            break;
                        case "telefono":
                            telefono = item.Value;
                            break;
                        case "direccion":
                            direccion = item.Value;
                            break;
                        case "correo":
                            correo = item.Value;
                            break;
                        case "password":
                            password = item.Value;
                            break;
                    }
                }
                if (empleado != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_empleado";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@empleado", MySqlDbType.Int16).Value = empleado;
                        cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 250).Value = nombre;
                        cmd.Parameters.Add("@direccion", MySqlDbType.VarChar, 250).Value = direccion;
                        cmd.Parameters.Add("@telefono", MySqlDbType.VarChar, 25).Value = telefono;
                        cmd.Parameters.Add("@correo", MySqlDbType.VarChar, 250).Value = correo;
                        cmd.Parameters.Add("@password", MySqlDbType.VarChar, 50).Value = password;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}