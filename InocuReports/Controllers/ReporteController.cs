using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InocuReports.Models;

namespace InocuReports.Controllers
{
    public class ReporteController : ApiController
    {
        ReporteAdmin ReporteAdmin = new ReporteAdmin();
        // GET: api/Reporte
        public IEnumerable<Reporte> Get()
        {
            return ReporteAdmin.GetReportes();
        }

        // GET: api/Reporte/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reporte
        public IHttpActionResult GuardarPaciente(Reporte nuevo)
        {
            ReporteAdmin.Guardar(nuevo);
            return Ok();
        }

        // PUT: api/Reporte/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reporte/5
        public void Delete(int id)
        {
        }
    }
}
