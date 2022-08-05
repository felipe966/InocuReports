using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Medico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Codigo_profesional { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre_completo { get; set; }
        [Display(Name = "Email / Correo eléctronico")]
        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress(ErrorMessage = "Formato invalido para el Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Pais { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Estado_provincia { get; set; }

    }
}