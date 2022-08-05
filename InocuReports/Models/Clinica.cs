using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InocuReports.Models
{
    public class Clinica
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Cedula_juridica { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Pais  { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Estado_provincia { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Distrito { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Telefono { get; set; }
        [Display(Name = "Email / Correo eléctronico")]
        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress(ErrorMessage = "Formato invalido para el Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", ErrorMessage = "Verificar el URL del sitio")]
        public string Sitio_web { get; set; }
    }
}