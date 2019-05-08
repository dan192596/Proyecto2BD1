using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Proyecto2BD1.proyecto2;

namespace Proyecto2BD1.Controllers
{
    public class DescuentoController : Controller
    {
        private readonly proyecto2Context _context = new proyecto2Context();
        private readonly IConfiguration configuration;
        public DescuentoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Descuento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Descuento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Descuento/Create
        public ActionResult Create()
        {
            var Producto = (from item in _context.Producto
                          select new SelectListItem()
                          {
                              Value = item.Producto1.ToString(),
                              Text = item.Nombre.ToString()
                          }).ToList();
            ViewData["ProductoProducto"] = Producto;
            return View();
        }

        // POST: Descuento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                String nodescuento = "";
                String descuento = "";
                String fechainicio = "";
                String fechafin = "";
                String producto = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "nodescuento":
                            nodescuento = item.Value;
                            break;
                        case "descuento1":
                            descuento = item.Value;
                            break;
                        case "fechainicio":
                            fechainicio = item.Value;
                            break;
                        case "fechafin":
                            fechafin = item.Value;
                            break;
                        case "productoproducto":
                            producto = item.Value;
                            break;
                    }
                }
                if (producto != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_descuento";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@_nodescuento", MySqlDbType.Int16).Value = nodescuento;
                        cmd.Parameters.Add("@_descuento", MySqlDbType.Int16).Value = descuento;
                        cmd.Parameters.Add("@_fechainicio", MySqlDbType.Date).Value = fechainicio;
                        cmd.Parameters.Add("@_fechafin", MySqlDbType.Date).Value = fechafin;
                        cmd.Parameters.Add("@_producto", MySqlDbType.Int16).Value = producto;
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

        // GET: Descuento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Descuento/Edit/5
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

        // GET: Descuento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Descuento/Delete/5
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