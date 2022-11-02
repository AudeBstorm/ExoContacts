using ExoContacts.APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExoContacts.APP.Controllers
{
    public class ContactController : Controller
    {

        //CRUD des contacts
        //C -> Create
        //R -> Read
        //U -> Update
        //D -> Delete

        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact { Id = 1, LastName = "Beurive", FirstName = "Aude", NickName = null, Phone = "0475 45 45 45", Mail = "aude.beurive@bstorm.be", BirthDate = new DateTime(1989, 10, 16), ContactType = "Collègue" },
             new Contact { Id = 2, LastName = "Chaineux", FirstName = "Gavin", NickName = "Skye", Phone = "0475 45 45 45", Mail = "gavin.chaineux@bstorm.be", BirthDate = new DateTime(1993, 10, 18), ContactType = "Collègue" }
        };

        //Action qui mène à la vue qui affichera la liste de nos contacts
        public IActionResult Index() //Read
        {
            return View(_contacts);
        }

        //Action d'ajout qui va mener à la vue qui affichera le formulaire pour ajouter un contact //Create

        //Action d'ajout qui ajouter les données du formulaire en "DB" et renvoyer à la liste de contacts ou rester sur la vue

        //Action d'update qui va mener à la vue qui affichera le formulaire pour éditer un contact (déjà prérempli) //Update

        //Action d'uptdate qui va modifier la "DB" avec les données du formulaires pour le contact en question

        //Action de suppression qui supprime le contact selectionné et renvoie à la liste de tous les contacts //Delete

    }
}
