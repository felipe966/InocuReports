using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Codigo_profesional { get; set; }
        public string Nombre_completo { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Estado_provincia { get; set; }

    }
}