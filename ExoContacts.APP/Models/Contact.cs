using System.ComponentModel.DataAnnotations;

namespace ExoContacts.APP.Models
{
    public class Contact
    {

        //Un contact se compose de :
        //Nom(Mettez un nb max de caractères)
        //Prenom(Mettez un nb max de caractères)
        //Surnom(optionnel)
        //Tel
        //Email
        //DateDeNaissance(optionnel)
        //TypeContact(famille, Collègue, ami etc) (Mettez ce que vous voulez, ne faites pas une entité pour ça, mettez la liste en dur)
        //(Pensez à ce qu'on ne voit pas mais utile, Id par ex ;))

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? NickName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string ContactType { get; set; }
    }
}
