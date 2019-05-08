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
    public class CategoriaController : Controller
    {

        private readonly IConfiguration configuration;
        public CategoriaController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM categoria", connection);
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[0].ToString());//categoria
                numb.Add(sdr[1].ToString());//nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                String categoria = "";
                String nombre = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "categoria1":
                            categoria = item.Value;
                            break;
                        case "nombre":
                            nombre = item.Value;
                            break;
                    }
                }
                if (categoria != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "insertar_categoria";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@categoria", MySqlDbType.Int16).Value = categoria;
                        cmd.Parameters.Add("@nombre", MySqlDbType.VarChar, 250).Value = nombre;
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

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                String categoria = "";
                foreach (var item in collection)
                {
                    System.Diagnostics.Debug.WriteLine(item.ToString());
                    switch (item.Key.ToString().ToLower())
                    {
                        case "categoria1":
                            categoria = item.Value;
                            break;
                    }
                }
                if (categoria != "")
                {
                    String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
                    MySqlConnection connection = new MySqlConnection(connectionstring);
                    connection.Open();
                    String sql = "eliminar_categoria";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@categoria", MySqlDbType.Int16).Value = categoria;
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