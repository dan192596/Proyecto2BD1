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
    public class ProductoController : Controller
    {

        private readonly IConfiguration configuration;
        public ProductoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                String producto = "";
                String nombre = "";
                String precioVenta = "";
                String existencia = "0";
                String precioCompra = "0";
                String categoria = "0";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "producto1":
                            producto = item.Value;
                            break;
                        case "nombre":
                            nombre = item.Value;
                            break;
                        case "precioventa":
                            precioVenta = item.Value;
                            break;
                    }
                }
                if (producto != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_productos";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@producto", MySqlDbType.Int16).Value = producto;
                        cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 250).Value = nombre;
                        cmd.Parameters.Add("@precio_venta", MySqlDbType.Double).Value = precioVenta;
                        cmd.Parameters.Add("@existencia", MySqlDbType.Int16).Value = existencia;
                        cmd.Parameters.Add("@precio_compra", MySqlDbType.Double).Value = precioCompra;
                        cmd.Parameters.Add("@categoria_categoria", MySqlDbType.Int16).Value = categoria;
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

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                String producto = "";
                String nombre = "";
                String precioVenta = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "producto1":
                            producto = item.Value;
                            break;
                        case "nombre":
                            nombre = item.Value;
                            break;
                        case "precioventa":
                            precioVenta = item.Value;
                            break;
                    }
                }
                if (producto != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "actualizar_productos";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@_producto", MySqlDbType.Int16).Value = producto;
                        cmd.Parameters.Add("@_nombre", MySqlDbType.VarChar, 250).Value = nombre;
                        cmd.Parameters.Add("@_precio_venta", MySqlDbType.Double).Value = precioVenta;
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

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                String producto = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "producto1":
                            producto = item.Value;
                            break;
                    }
                }
                if (producto != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "eliminar_producto";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@_producto", MySqlDbType.Int16).Value = producto;
                        //cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 250).Value = nombre;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return RedirectToAction(nameof(Delete));
            }
            catch
            {
                return View();
            }
        }

    }
}