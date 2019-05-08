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
    public class ClienteController : Controller
    {

        private readonly IConfiguration configuration;
        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["Empleado"] = VariablesGlobales.Empleado;
                ViewData["Nombre"] = VariablesGlobales.Nombre;

                String nit = "";
                String nombre = "";
                String dpi = "";
                String telefono = "";
                String correo = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "nit":
                            nit = item.Value;
                            break;
                        case "nombre":
                            nombre = item.Value;
                            break;
                        case "telefono":
                            telefono = item.Value;
                            break;
                        case "dpi":
                            dpi = item.Value;
                            break;
                        case "correo":
                            correo = item.Value;
                            break;
                    }
                }
                if (nit != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_cliente";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@nit", MySqlDbType.Int16).Value = nit;
                        cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 250).Value = nombre;
                        cmd.Parameters.Add("@dpi", MySqlDbType.VarChar, 250).Value = dpi;
                        cmd.Parameters.Add("@telefono", MySqlDbType.VarChar, 25).Value = telefono;
                        cmd.Parameters.Add("@correo", MySqlDbType.VarChar, 250).Value = correo;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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