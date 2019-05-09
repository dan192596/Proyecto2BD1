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
    public class CompraController : Controller
    {
        private readonly proyecto2Context _context = new proyecto2Context();
        private readonly IConfiguration configuration;
        public CompraController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: Compra
        public ActionResult Index()
        {
            return View();
        }

        // GET: Compra/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            var Proveedor = (from item in _context.Proveedor
                            select new SelectListItem()
                            {
                                Value = item.Proveedor1.ToString(),
                                Text = item.Nombre.ToString()
                            }).ToList();
            ViewData["ProveedorProveedor"] = Proveedor;

            var Producto = (from item in _context.Producto
                             select new SelectListItem()
                             {
                                 Value = item.Producto1.ToString(),
                                 Text = item.Nombre.ToString()
                             }).ToList();
            ViewData["ProductoProducto"] = Producto;
            return View();

            /*
             <div class="form-group">
                <label asp-for="CompraCompra" class="control-label"></label>
                <input asp-for="CompraCompra" class="form-control" />
                <span asp-validation-for="CompraCompra" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="ProductoProducto" class="control-label"></label>
                <select asp-for="ProductoProducto" class="form-control" asp-items="ViewBag.ProductoProducto"></select>
            </div>
             */
        }

        // POST: Compra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                String detalle = "";
                String producto = "";
                String fecha = "";
                String total = "";
                String subtotal = "";
                String cantidad = "";
                String usuario = "";
                String factura = "";
                String proveedor = "";
                String aux = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "detalle":
                            detalle = item.Value;
                            break;
                        case "productoproducto":
                            producto = item.Value;
                            break;
                        case "fecha":
                            fecha = item.Value;
                            break;
                        case "total":
                            total = item.Value;
                            break;
                        case "subtotal":
                            subtotal = item.Value;
                            break;
                        case "cantidad":
                            cantidad = item.Value;
                            break;
                        case "usuario":
                            usuario = item.Value;
                            break;
                        case "factura":
                            factura = item.Value;
                            break;
                        case "proveedorproveedor":
                            proveedor = item.Value;
                            break;
                    }
                }
                if (detalle != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "SELECT existencia FROM producto P WHERE P.producto = " + producto;
                    MySqlCommand com = new MySqlCommand(sql, connection);
                    MySqlDataReader sdr = com.ExecuteReader();
                    while (sdr.Read())
                    {
                        aux = sdr[0].ToString();//Id
                    }
                    connection.Close();
                }
                if (detalle != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_compra";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@_nofactura", MySqlDbType.Int16).Value = factura;
                        cmd.Parameters.Add("@_fecha", MySqlDbType.Date).Value = fecha;
                        cmd.Parameters.Add("@_total", MySqlDbType.Decimal).Value = total;
                        cmd.Parameters.Add("@_proveedor", MySqlDbType.Int16).Value = proveedor;
                        cmd.Parameters.Add("@_empleado", MySqlDbType.Int16).Value = usuario;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                if (detalle != "")
                {
                    int cantidad1 = Int16.Parse(aux);
                    int cantidad2 = Int16.Parse(cantidad);
                    cantidad1 += cantidad2;

                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_detalleCompra";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@_detalle", MySqlDbType.Int16).Value = detalle;
                        cmd.Parameters.Add("@_cantidad", MySqlDbType.Int16).Value = cantidad;
                        cmd.Parameters.Add("@_subtotal", MySqlDbType.Decimal).Value = subtotal;
                        cmd.Parameters.Add("@_facturaFactura", MySqlDbType.Int16).Value = factura;
                        cmd.Parameters.Add("@_productoProducto", MySqlDbType.Int16).Value = producto;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                if (detalle != "")
                {
                    int cantidad1 = Int16.Parse(aux);
                    int cantidad2 = Int16.Parse(cantidad);
                    cantidad1 += cantidad2;

                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);

                    connection.Open();
                    String sql = "actualizar_productoExistencia";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@_producto", MySqlDbType.Int16).Value = producto;
                        cmd.Parameters.Add("@_existencia", MySqlDbType.Int16).Value = cantidad1;
                        cmd.Parameters.Add("@_precioCompra", MySqlDbType.Decimal).Value = subtotal;
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

        // GET: Compra/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Compra/Edit/5
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

        // GET: Compra/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compra/Delete/5
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