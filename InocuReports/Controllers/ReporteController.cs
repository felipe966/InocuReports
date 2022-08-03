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

        // GET: api/Reporte/maxid
        public int Get(string rq)
        {
            if (rq == "maxid")
            {
                int last_id = ReporteAdmin.GetLastId();
                return last_id;
            }
            else
            {
                return 0;
            }
            
        }

        // POST: api/Reporte
        public IHttpActionResult GuardarPaciente(Reporte nuevo)
        {
            int new_id = ReporteAdmin.Guardar(nuevo);
            return Ok(new_id);
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
