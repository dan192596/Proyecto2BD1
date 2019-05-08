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
    public class ProveedorController : Controller
    {
        private readonly IConfiguration configuration;
        public ProveedorController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ViewData["Empleado"] = VariablesGlobales.Empleado;
                ViewData["Nombre"] = VariablesGlobales.Nombre;

                String proveedor = "";
                String nombre = "";
                String direccion = "";
                String correo = "";
                String telefono = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "proveedor1":
                            proveedor = item.Value;
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
                    }
                }
                if (proveedor != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_proveedores";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@proveedor", MySqlDbType.Int16).Value = proveedor;
                        cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 250).Value = nombre;
                        cmd.Parameters.Add("@direccion", MySqlDbType.VarChar, 250).Value = direccion;
                        cmd.Parameters.Add("@correo", MySqlDbType.VarChar, 50).Value = correo;
                        cmd.Parameters.Add("@telefono", MySqlDbType.VarChar, 50).Value = telefono;
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

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proveedor/Edit/5
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

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proveedor/Delete/5
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