using System.ComponentModel.DataAnnotations;

namespace ExoContacts.APP.Models
{
    public class AuthLoginModel
    {
        [EmailAddress(ErrorMessage = "L'email est invalide")]
        [Required(ErrorMessage="L'email est requis")]
        [Display(Name = "Votre adresse mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
