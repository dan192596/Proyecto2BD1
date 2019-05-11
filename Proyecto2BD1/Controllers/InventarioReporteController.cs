using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Proyecto2BD1.proyecto2;

namespace Proyecto2BD1.Controllers
{
    public class InventarioReporteController : Controller
    {

        private readonly proyecto2Context _context = new proyecto2Context();
        private readonly IConfiguration configuration;
        public InventarioReporteController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: InventarioReporte
        public ActionResult Index()
        {
            return View();
        }

        // GET: InventarioReporte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventarioReporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventarioReporte/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventarioReporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventarioReporte/Edit/5
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

        // GET: InventarioReporte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventarioReporte/Delete/5
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

        // GET: InventarioReporte/Create
        public ActionResult Reporte1()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            String sql = "compra_reporte1";
            MySqlCommand com = new MySqlCommand(sql, connection);
            com.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[0].ToString());//nombre
                numb.Add(sdr[1].ToString());//nombre
                numb.Add(sdr[2].ToString());//nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

        public ActionResult Reporte2()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            String sql = "compra_reporte2";
            MySqlCommand com = new MySqlCommand(sql, connection);
            com.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[0].ToString());//nombre
                numb.Add(sdr[1].ToString());//nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

        public ActionResult Reporte3()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            String sql = "compra_reporte3";
            MySqlCommand com = new MySqlCommand(sql, connection);
            com.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[0].ToString());//nombre
                numb.Add(sdr[1].ToString());//nombre
                numb.Add(sdr[2].ToString());//nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

        public ActionResult Reporte4()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            String sql = "compra_reporte4";
            MySqlCommand com = new MySqlCommand(sql, connection);
            com.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[0].ToString());
                numb.Add(sdr[1].ToString());//nombre
                numb.Add(sdr[2].ToString());//nombre
                numb.Add(sdr[3].ToString());//nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

        public ActionResult Reporte5()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            String sql = "compra_reporte5";
            MySqlCommand com = new MySqlCommand(sql, connection);
            com.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[0].ToString());//nombre
                numb.Add(sdr[1].ToString());//nombre
                numb.Add(sdr[2].ToString());//nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

        public ActionResult Reporte6()
        {
            ViewData["Empleado"] = VariablesGlobales.Empleado;
            ViewData["Nombre"] = VariablesGlobales.Nombre;
            String connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            MySqlConnection connection = new MySqlConnection(connectionstring);
            List<List<String>> al = new List<List<String>>();
            connection.Open();
            String sql = "compra_reporte6";
            MySqlCommand com = new MySqlCommand(sql, connection);
            com.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                List<String> numb = new List<string>();
                numb.Add(sdr[1].ToString());//nombre
                numb.Add(sdr[2].ToString());//nombre
                numb.Add(sdr[3].ToString());//nombre
                numb.Add(sdr[4].ToString());//nombre
                numb.Add(sdr[5].ToString());//nombre
                al.Add(numb);
            }
            connection.Close();
            return View(al);
        }

    }
}