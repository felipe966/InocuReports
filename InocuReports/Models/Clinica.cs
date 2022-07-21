using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Clinica
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Cedula_juridica { get; set; }
        public string Pais  { get; set; }
        public string Estado_provincia { get; set; }
        public string Distrito { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Sitio_web { get; set; }
    }
}