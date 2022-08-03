using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InocuReports.Models;

namespace InocuReports.Controllers
{
    public class PacienteController : ApiController
    {
        PacienteAdmin PacienteAdmin = new PacienteAdmin();  
        // GET: api/Paciente
        public IEnumerable<Paciente> Get()
        {
            return PacienteAdmin.GetPacientes();
        }

        // GET: api/Paciente/5
        public Paciente Get(int id)
        {
            return PacienteAdmin.GetById(id);
        }

        // POST: api/Paciente
        public IHttpActionResult GuardarPaciente(Paciente nuevo)
        {
            int new_id = PacienteAdmin.Guardar(nuevo);
            return Ok(new_id);
        }


        // PUT: api/Paciente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Paciente/5
        public void Delete(int id)
        {
        }
    }
}
