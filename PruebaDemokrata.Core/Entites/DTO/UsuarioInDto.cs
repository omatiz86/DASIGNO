using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Core.Entites.DTO
{
    public class UsuarioInDto
    {

        //public int Id { get; set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El primer nombre debe tener como máximo 50 caracteres.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El primer nombre no debe contener números.")]
        public string PrimerNombre { get; set; } = null;

        [StringLength(50, ErrorMessage = "El segundo nombre debe tener como máximo 50 caracteres.")]
        [RegularExpression(@"^[^\d]*$", ErrorMessage = "El segundo nombre no debe contener números.")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El primer apellido debe tener como máximo 50 caracteres.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "El primer apellido no debe contener números.")]
        public string PrimerApellido { get; set; } = null!;

        [StringLength(50, ErrorMessage = "El segundo apellido debe tener como máximo 50 caracteres.")]
        [RegularExpression(@"^[^\d]*$", ErrorMessage = "El segundo apellido no debe contener números.")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El sueldo es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo debe ser mayor que 0.")]
        public decimal Sueldo { get; set; }

        public DateTime? FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? FechaModificacion { get; set; } = new DateTime(1900, 1, 1, 00, 00, 00, 000);



    }
}
