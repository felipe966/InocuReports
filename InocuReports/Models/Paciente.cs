using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Primer_apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Segundo_apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string Fecha_nacimiento { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Sexo_natural { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Telefono_contacto { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Pais { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Estado_provincia { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Distrito { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Estado_civil { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Telefono_personal { get; set; }
        [Display(Name = "Email / Correo eléctronico")]
        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress(ErrorMessage = "Formato invalido para el Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Fecha_registro { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Ocupacion { get; set; }


    }
}