using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InocuReports.Models;
using System.Net.Http;

namespace InocuReports.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            IEnumerable<Reporte> reportes = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44384/api/reporte");
            var consumeapi = hc.GetAsync("medico");
            consumeapi.Wait();

            var read = consumeapi.Result;
            if (read.IsSuccessStatusCode)
            {
                var data = read.Content.ReadAsAsync<IList<Reporte>>();
                data.Wait();
                reportes = data.Result;
            }

            return View(reportes);
        }
        public ActionResult Reportes()
        {
            IEnumerable<Reporte> reportes = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44384/api/reporte");
            var consumeapi = hc.GetAsync("reporte");
            consumeapi.Wait();

            var read = consumeapi.Result;
            if (read.IsSuccessStatusCode)
            {
                var data = read.Content.ReadAsAsync<IList<Reporte>>();
                data.Wait();
                reportes = data.Result;
            }

            return View(reportes);
        }

        public ActionResult Medicos()
        {
            IEnumerable<Medico> medico = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44384/api/medico");
            var consumeapi = hc.GetAsync("medico");
            consumeapi.Wait();

            var read = consumeapi.Result;
            if (read.IsSuccessStatusCode)
            {
                var data = read.Content.ReadAsAsync<IList<Medico>>();
                data.Wait();
                medico = data.Result;
            }

            return View(medico);
        }

        public ActionResult Clinicas()
        {
            IEnumerable<Clinica> clinica = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44384/api/clinica");
            var consumeapi = hc.GetAsync("clinica");
            consumeapi.Wait();

            var read = consumeapi.Result;
            if (read.IsSuccessStatusCode)
            {
                var data = read.Content.ReadAsAsync<IList<Clinica>>();
                data.Wait();
                clinica = data.Result;
            }

            return View(clinica);
        }

        public ActionResult Pacientes()
        {
            IEnumerable<Paciente> paciente = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44384/api/paciente");
            var consumeapi = hc.GetAsync("paciente");
            consumeapi.Wait();

            var read = consumeapi.Result;
            if (read.IsSuccessStatusCode)
            {
                var data = read.Content.ReadAsAsync<IList<Paciente>>();
                data.Wait();
                paciente = data.Result;
            }

            return View(paciente);
        }

        public ActionResult Inyecciones()
        {
            IEnumerable<Inyeccion> inyeccion = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44384/api/paciente");
            var consumeapi = hc.GetAsync("inyeccion");
            consumeapi.Wait();

            var read = consumeapi.Result;
            if (read.IsSuccessStatusCode)
            {
                var data = read.Content.ReadAsAsync<IList<Inyeccion>>();
                data.Wait();
                inyeccion = data.Result;
            }

            return View(inyeccion);
        }

        // GET: App/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: App/Paso1
        public ActionResult Paso1()
        {
            Session["Codigo_registro"] = "COD-RE302158";
            ViewBag.Codigo_registro = Session["Codigo_registro"];
            return View();
        }

        // POST: App/Paso1
        [HttpPost]
        public ActionResult Paso1(Medico obj)
        {
            try
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44384/api/");
                var consumeapi = hc.PostAsJsonAsync<Medico>("medico", obj);
                consumeapi.Wait();

                var data = consumeapi.Result;
                if (data.IsSuccessStatusCode)
                {
                    ViewBag.Codigo_registro= Session["Codigo_registro"];
                    Session["Nombre_medico"]=obj.Nombre_completo;
                    return RedirectToAction("Paso2");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Paso2
        public ActionResult Paso2()
        {
            ViewBag.Codigo_registro = Session["Codigo_registro"];
            ViewBag.Nombre_medico = Session["Nombre_medico"];
            return View();
        }

        // POST: App/Paso2
        [HttpPost]
        public ActionResult Paso2(Clinica obj)
        {
            try
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44384/api/");
                var consumeapi = hc.PostAsJsonAsync<Clinica>("clinica", obj);
                consumeapi.Wait();

                var data = consumeapi.Result;
                if (data.IsSuccessStatusCode)
                {
                    ViewBag.Codigo_registro = Session["Codigo_registro"];
                    ViewBag.Nombre_medico = Session["Nombre_medico"];
                    Session["Nombre_clinica"] = obj.Nombre;
                    return RedirectToAction("Paso3");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Paso3
        public ActionResult Paso3()
        {
            ViewBag.Codigo_registro = Session["Codigo_registro"];
            ViewBag.Nombre_medico = Session["Nombre_medico"];
            ViewBag.Nombre_clinica = Session["Nombre_clinica"];
            return View();
        }

        // POST: App/Paso3
        [HttpPost]
        public ActionResult Paso3(Paciente obj)
        {
            try
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44384/api/");
                var consumeapi = hc.PostAsJsonAsync<Paciente>("paciente", obj);
                consumeapi.Wait();

                var data = consumeapi.Result;
                if (data.IsSuccessStatusCode)
                {
                    Session["Nombre_paciente"] = obj.Nombre;
                    ViewBag.Codigo_registro = Session["Codigo_registro"];
                    ViewBag.Nombre_medico = Session["Nombre_medico"];
                    ViewBag.Nombre_clinica = Session["Nombre_clinica"];
                    return RedirectToAction("Paso4");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Paso4
        public ActionResult Paso4()
        {
            ViewBag.Codigo_registro = Session["Codigo_registro"];
            ViewBag.Nombre_medico = Session["Nombre_medico"];
            ViewBag.Nombre_clinica = Session["Nombre_clinica"];
            ViewBag.Nombre_paciente=Session["Nombre_paciente"];
            return View();
        }

        // POST: App/Paso4
        [HttpPost]
        public ActionResult Paso4(Inyeccion obj)
        {
            try
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44384/api/");
                var consumeapi = hc.PostAsJsonAsync<Inyeccion>("inyeccion", obj);
                consumeapi.Wait();

                var data = consumeapi.Result;
                if (data.IsSuccessStatusCode)
                {
                    Session["Nombre_inyeccion"] = obj.Nombre;
                    ViewBag.Codigo_registro = Session["Codigo_registro"];
                    ViewBag.Nombre_medico = Session["Nombre_medico"];
                    ViewBag.Nombre_clinica = Session["Nombre_clinica"];
                    ViewBag.Nombre_paciente = Session["Nombre_paciente"];
                    return RedirectToAction("Paso5");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Paso5
        public ActionResult Paso5()
        {
            ViewBag.Codigo_registro = Session["Codigo_registro"];
            ViewBag.Nombre_medico = Session["Nombre_medico"];
            ViewBag.Nombre_clinica = Session["Nombre_clinica"];
            ViewBag.Nombre_paciente = Session["Nombre_paciente"];
            ViewBag.Nombre_inyeccion = Session["Nombre_inyeccion"];
            return View();
        }

        // POST: App/Paso5
        [HttpPost]
        public ActionResult Paso5(Reporte obj)
        {
            try
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44384/api/");
                var consumeapi = hc.PostAsJsonAsync<Reporte>("reporte", obj);
                consumeapi.Wait();

                var data = consumeapi.Result;
                if (data.IsSuccessStatusCode)
                {
                    return RedirectToAction("Reportes");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: App/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: App/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
