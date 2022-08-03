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
        public Clinica Get(string cedula)
        {
            return ClinicaAdmin.GetClinicaByCedula(cedula)[0];
        }
        

        public Clinica Get(int id_clinica)
        {
            return ClinicaAdmin.GetById(id_clinica);
        }

        // POST: api/clinica
        public IHttpActionResult GuardarClinica(Clinica nuevo)
        {
            int new_id = ClinicaAdmin.Guardar(nuevo);
            return Ok(new_id);
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
