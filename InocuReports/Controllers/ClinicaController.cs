using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InocuReports.Models;

namespace InocuReports.Controllers
{
    public class ClinicaController : ApiController
    {
        ClinicaAdmin ClinicaAdmin = new ClinicaAdmin();
        // GET: api/Clinica
        public IEnumerable<Clinica> Get()
        {
            return ClinicaAdmin.GetClinicas();
        }

        // GET: api/Clinica/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/clinica
        public IHttpActionResult GuardarMedico(Clinica nuevo)
        {
            ClinicaAdmin.Guardar(nuevo);
            return Ok();
        }

        // PUT: api/Clinica/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clinica/5
        public void Delete(int id)
        {
        }
    }
}
