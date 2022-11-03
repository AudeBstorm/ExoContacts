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
            return View(_contacts.OrderBy(c => c.LastName).ToList()); //En renvoie la vue Index, en lui fournissant la liste des contacts
        }

        //Action d'ajout qui va mener à la vue qui affichera le formulaire pour ajouter un contact //Create
        public IActionResult Create()
        {
            return View();
        }
        
        //Action d'ajout qui ajouter les données du formulaire en "DB" et renvoyer à la liste de contacts ou rester sur la vue
        [HttpPost]
        public IActionResult Create(Contact contactToAdd)
        {
            if(ModelState.IsValid) //Si le formulaire est valide
            {
                //On commence par lui créer un Id (uniquement parce que fakeDB)
                contactToAdd.Id = _contacts.Max(c => c.Id) + 1;
                //Ajout en "DB"
                _contacts.Add(contactToAdd);
                //Redirection vers la vue liste de tous les contacts
                return RedirectToAction("Index");
            }
            //Si modèle pas valide, on renvoie la même vue mais avec les données du formulaires
            return View(contactToAdd);
        }

        //Action d'update qui va mener à la vue qui affichera le formulaire pour éditer un contact (déjà prérempli) //Update
        public IActionResult Update(int id)
        {
            Contact? contactToEdit = _contacts.FirstOrDefault(c => c.Id == id);
            return View(contactToEdit);
        }

        //Action d'uptdate qui va modifier la "DB" avec les données du formulaires pour le contact en question
        [HttpPost]
        public IActionResult Update(Contact contactEdited)
        {
            if (ModelState.IsValid)
            {
                //Mise à jour en "DB"
                Contact? contact = _contacts.FirstOrDefault(c => c.Id == contactEdited.Id);
                _contacts.Remove(contact);
                _contacts.Add(contactEdited);
                return RedirectToAction("Index");
            }
            return View(contactEdited);
        }
        //Action de suppression qui supprime le contact selectionné et renvoie à la liste de tous les contacts //Delete
        public IActionResult Delete(int id)
        {
            Contact? contactToDelete = _contacts.FirstOrDefault(c => c.Id == id);
            if (contactToDelete != null)//si on a trouvé le contact, on le supprime de la "DB"
            {
                _contacts.Remove(contactToDelete);
                //_contacts.RemoveAll(c => c.Id == id);
                return RedirectToAction("Index");
                
            }
            return RedirectToAction("Index");
        }

    }
}
