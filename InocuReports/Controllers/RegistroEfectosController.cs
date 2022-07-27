using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InocuReports.Models;
using System.Net.Http;

namespace InocuReports.Controllers
{
    public class RegistroEfectosController : Controller
    {
        // GET: Paso1
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

        [HttpPost]
        public ActionResult Paso1(Medico nuevo_medico)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44384/api/");
            var consumeapi = hc.PostAsJsonAsync<Medico>("medico", nuevo_medico);
            consumeapi.Wait();

            var data = consumeapi.Result;
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Medicos");
            }
            return View("Paso1");
        }
    }
}