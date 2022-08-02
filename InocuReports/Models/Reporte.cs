using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string[] Resp_opts_1 { get; set; }
        public string[] Resp_opts_3 { get; set; }
        public string[] Resp_opts_5 { get; set; }
        public string[] Resp_opts_8 { get; set; }


        public  List<Option> Opts_1 { get; set; }
        public  List<Option> Opts_3 { get; set; }
        public  List<Option> Opts_5 { get; set; }
        public  List<Option> Opts_8 { get; set; }



    }
}