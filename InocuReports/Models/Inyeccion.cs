using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Inyeccion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Fecha_aplicacion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Numero_lote { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Fecha_vencimiento { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Lugar_aplicacion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Observaciones { get; set; }
        public string Cuestionario { get; set; }
    }
}