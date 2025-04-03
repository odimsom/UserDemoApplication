using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Usuario", Schema = "dbo")]
    public class Usuario
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="El Mail es requerido")]
        [StringLength(100, MinimumLength = 9)]
        [EmailAddress(ErrorMessage = "El Formato del mail es incorrecto")]
        public string Correo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [PasswordPropertyText]
        public string Contrasenia { get; set; }
    }
}
