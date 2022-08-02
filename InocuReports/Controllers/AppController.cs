using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InocuReports.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace InocuReports.Controllers
{
    public class AppController : Controller
    {

        IDictionary<string, string> Cuestionario_inyeccion = new Dictionary<string, string>();
        IDictionary<string, string> Cuestionario_reporte = new Dictionary<string, string>();

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
                    Session["Nombre_medico"] = obj.Nombre_completo;
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
            Session["InyPreg1"] = "¿Ha tenido COVID previo a inyectarse?";
            Session["InyPreg2"] = "¿Ha tenido sospecha de haber tenido COVID antes de ponerte la inyección ?";
            Session["InyPreg3"] = "¿Ha tenido COVID después de tomar la inyección?";
            Session["InyPreg4"] = "¿Razón de inyectarse contra COVID?";
            Session["InyPreg5"] = "¿Estaba embarazada al inyectarse contra COVID? (Si aplica)";
            Session["InyPreg6"] = "¿Ha tenido reacciones a vacunas en el pasado?";
            Session["InyPreg7"] = "Especifique las reacciones a vacunas en el pasado";
            Session["InyPreg8"] = "Medicamentos actuales con receta, enumere todos los medicamentos y las dosis";
            Session["InyPreg9"] = "Nuevos medicamentos recetados que tuvieron que ser iniciados después de la(s) inyección(es) de COVID";

            return View();
        }

        // POST: App/Paso4
        [HttpPost]
        public ActionResult Paso4(Inyeccion obj)
        {
            Cuestionario_inyeccion.Add(Session["InyPreg1"].ToString(), Request["rsp_1"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg2"].ToString(), Request["rsp_2"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg3"].ToString(), Request["rsp_3"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg4"].ToString(), Request["rsp_4"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg5"].ToString(), Request["rsp_5"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg6"].ToString(), Request["rsp_6"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg7"].ToString(), Request["rsp_7"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg8"].ToString(), Request["rsp_8"].ToString());
            Cuestionario_inyeccion.Add(Session["InyPreg9"].ToString(), Request["rsp_9"].ToString());

            Session["Cuestionario_inyeccion"] = JsonConvert.SerializeObject(Cuestionario_inyeccion);
            obj.Cuestionario = Session["Cuestionario_inyeccion"].ToString();
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
            Session["EfecPreg1"] = "Resultado del evento adverso o de los síntomas (marque todo lo que corresponda)";
            Session["EfecPreg2"] = "¿Se mantiene los síntomas?";
            Session["EfecPreg3"] = "¿Alergias conocidas?";
            Session["EfecPreg4"] = "Descripción de alergias conocidas";
            Session["EfecPreg5"] = "Nuevas enfermedades desde su inyección";
            Session["EfecPreg6"] = "Especifique otras condiciones";
            Session["EfecPreg7"] = "¿Si ha desarrollado un nuevo cáncer o la reaparición de un cáncer existente después de la inyección de COVID, especifique el tipo de cáncer?";
            Session["EfecPreg8"] = "¿Desde la inyección de COVID, ha tenido alguno de los siguientes síntomas ?";
            var mv = new Reporte();
            mv.Opts_1 = GeneraOpt_1();
            mv.Opts_3 = GeneraOpt_3();
            mv.Opts_5 = GeneraOpt_5();
            mv.Opts_8 = GeneraOpt_1();
            return View(mv);

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

        public List<Option> GeneraOpt_1()
        {
            List<Option> opts = new List<Option>();
            opts.Add(new Option { text = "Visita al médico o a la consulta de otro profesional de la salud" });
            opts.Add(new Option { text = "Visita a la sala de emergencias o al centro de atención urgente" });
            opts.Add(new Option { text = "Hospitalización" });
            opts.Add(new Option { text = "Hospitalización prolongada (inyección de COVID recibida en el hospital)" });
            opts.Add(new Option { text = "Enfermedad que pone en peligro la vida" });
            opts.Add(new Option { text = "Incapacidad o daño permanente" });
            opts.Add(new Option { text = "Paciente fallecido" });
            opts.Add(new Option { text = "Anomalía congénita o defecto de nacimiento" });
            opts.Add(new Option { text = "Aborto espontáneo o nacimiento sin vida" });
            opts.Add(new Option { text = "Ninguna de las anteriores" });
            return opts;

        }
        public List<Option> GeneraOpt_3()
        {
            List<Option> opts = new List<Option>();
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Polietilenglicol" });
            opts.Add(new Option { text = "Alimentos" });
            opts.Add(new Option { text = "Medio ambiente" });
            opts.Add(new Option { text = "Otros" });
            return opts;

        }
        public List<Option> GeneraOpt_5()
        {
            List<Option> opts = new List<Option>();
            opts.Add(new Option { text = "Enfermedad de Addison" });
            opts.Add(new Option { text = "Alergias" });
            opts.Add(new Option { text = "Arritmias" });
            opts.Add(new Option { text = "Fibrilación auricular" });
            opts.Add(new Option { text = "Vasculitis autoinmune" });
            opts.Add(new Option { text = "Parálisis de Bell (parálisis facial)" });
            opts.Add(new Option { text = "Bronquitis" });
            opts.Add(new Option { text = "Cáncer" });
            opts.Add(new Option { text = "Enfermedad celíaca (intolerancia al gluten)" });
            opts.Add(new Option { text = "Enfermedad renal crónica" });
            opts.Add(new Option { text = "Insuficiencia cardíaca congestiva" });
            opts.Add(new Option { text = "Enfermedad de Crohn" });
            opts.Add(new Option { text = "TVP (coágulos de sangre)" });
            opts.Add(new Option { text = "Diabetes" });
            opts.Add(new Option { text = "Encefalitis (inflamación cerebral/dolores de cabeza)" });
            opts.Add(new Option { text = "Epilepsia (convulsiones)" });
            opts.Add(new Option { text = "Enfermedades del corazón" });
            opts.Add(new Option { text = "Herpes tipo 1" });
            opts.Add(new Option { text = "Herpes tipo 2" });
            opts.Add(new Option { text = "VIH" });
            opts.Add(new Option { text = "Hipertensión (presión arterial alta)" });
            opts.Add(new Option { text = "Enfermedad inflamatoria intestinal" });
            opts.Add(new Option { text = "Enfermedad renal aguda" });
            opts.Add(new Option { text = "Enfermedad hepática" });
            opts.Add(new Option { text = "Lupus" });
            opts.Add(new Option { text = "Aborto espontáneo" });
            opts.Add(new Option { text = "Esclerosis múltiple" });
            opts.Add(new Option { text = "Miastenia gravis" });
            opts.Add(new Option { text = "Infarto de miocardio (ataque al corazón)" });
            opts.Add(new Option { text = "Miocarditis" });
            opts.Add(new Option { text = "Osteoartritis" });
            opts.Add(new Option { text = "Pericarditis" });
            opts.Add(new Option { text = "Anemia perniciosa" });
            opts.Add(new Option { text = "Neumonía" });
            opts.Add(new Option { text = "Parto prematuro" });
            opts.Add(new Option { text = "Psoriasis" });
            opts.Add(new Option { text = "Artritis psoriásica" });
            opts.Add(new Option { text = "Embolia pulmonar" });
            opts.Add(new Option { text = "Artritis reumatoide" });
            opts.Add(new Option { text = "Herpes zóster" });
            opts.Add(new Option { text = "Síndrome de Sjogren" });
            opts.Add(new Option { text = "Nacimiento sin vida" });
            opts.Add(new Option { text = "Accidente cerebrovascular" });
            opts.Add(new Option { text = "Ataques isquémicos transitorios (AIT)" });
            opts.Add(new Option { text = "Trastorno de la tiroides" });
            opts.Add(new Option { text = "Colitis ulcerosa" });
            return opts;
        }

        public List<Option> GeneraOpt_8()
        {
            List<Option> opts = new List<Option>();
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            opts.Add(new Option { text = "Medicamentos" });
            return opts;
        }
    }

    }
