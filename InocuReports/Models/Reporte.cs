using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Reporte
    {
        public int Id { get; set; }     
        public string Codigo_registro { get; set; }
        public int Id_medico { get; set; }
        public int Id_clinica { get; set; }
        public int Id_paciente { get; set; }
        public int Id_inyeccion { get; set; }
        public string Cuestionario  { get; set; }   


    }
}