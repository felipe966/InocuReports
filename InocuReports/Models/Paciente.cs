using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Paciente
    {
        public int Id { get; set; } 
        public string Identificacion { get; set; }  
        public string Nombre { get; set; }  
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Fecha_nacimiento { get; set; }
        public string Sexo_natural { get; set; }
        public string Telefono_contacto { get; set; }
        public string Pais { get; set; }
        public string Estado_provincia { get; set; }
        public string Distrito { get; set; }
        public string Estado_civil { get; set; }
        public string Telefono_personal { get; set; }
        public string Email { get; set; }
        public string Fecha_registro { get; set; }
        public string Ocupacion { get; set; }

    }
}