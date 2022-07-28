using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InocuReports.Models;

namespace InocuReports.Controllers
{
    public class InyeccionController : ApiController
    {
        InyeccionAdmin InyeccionAdmin = new InyeccionAdmin();
        // GET: api/Inyeccion
        public IEnumerable<Inyeccion> Get()
        {
            return InyeccionAdmin.GetInyecciones();
        }

        // GET: api/Inyeccion/5
        public Inyeccion Get(int id)
        {
            return InyeccionAdmin.GetInyeccionById(id)[0];
        }

        // POST: api/Inyeccion
        public IHttpActionResult GuardarPaciente(Inyeccion nuevo)
        {
            InyeccionAdmin.Guardar(nuevo);
            return Ok();
        }

        // PUT: api/Inyeccion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inyeccion/5
        public void Delete(int id)
        {
        }
    }
}
