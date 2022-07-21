using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Inyeccion
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Fecha_aplicacion { get; set; }
        public string Numero_lote { get; set; }
        public string Fecha_vencimiento { get; set; }
        public string Lugar_aplicacion { get; set; }
        public string Observaciones { get; set; }
        public string Cuestionario { get; set; }
    }
}