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
        public Medico Get(string id)
        {
            return MedicoAdmin.GetMedicoByIdentificacion(id)[0];
        }
        // GET: api/Medico/codigo/5
        public Medico GetByCodigo(string codigo)
        {
            return MedicoAdmin.GetMedicoByCodigoProfesional(codigo)[0];
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
