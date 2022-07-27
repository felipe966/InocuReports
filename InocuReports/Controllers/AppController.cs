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
            hc.BaseAddress = new Uri("https://localhost:44384/api/medico");
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

        // GET: App/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: App/Paso1
        public ActionResult Paso1()
        {
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
                    return RedirectToAction("Paso2");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        // GET: App/Paso1
        public ActionResult Paso2()
        {
            return View();
        }

        // POST: App/Paso1
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
                    return RedirectToAction("Clinicas");
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
