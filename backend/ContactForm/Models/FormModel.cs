using System.ComponentModel.DataAnnotations;

namespace ContactForm.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Debe tener entre 2 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; } = string.Empty;

        [RegularExpression(@"^$|^\d{10}$", ErrorMessage = "El celular debe tener 10 dígitos")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Selecciona una categoría")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Mensaje es obligatorio")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "El mensahe debe tener al menos 10 caracteres")]
        public string Message { get; set; } = string.Empty;
    }
}
