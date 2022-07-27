using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InocuReports.Models;

namespace InocuReports.Controllers
{
    public class MedicoController : ApiController
    {
        MedicoAdmin MedicoAdmin = new MedicoAdmin();
        // GET: api/Medico
        public IEnumerable<Medico> Get()
        {
            
            return MedicoAdmin.GetMedicos();
        }

        // GET: api/Medico/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Medico
        public IHttpActionResult GuardarMedico(Medico nuevo)
        {
            MedicoAdmin.Guardar(nuevo);
            return Ok();  
        }

        // PUT: api/Medico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Medico/5
        public void Delete(int id)
        {
        }
    }
}
