
using ExoContacts.DAL.Repositories;
using ExoContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoContacts.BLL.Services
{
    public class ContactService
    {
        private ContactRepository _contactRepo;

        public ContactService(ContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactRepo.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactRepo.GetById(id);
        }

        public int Create(Contact contactToAdd)
        {

            return _contactRepo.Add(contactToAdd);
        }

        public bool Update(int id, Contact contactToUpdate)
        {
            return _contactRepo.Update(id, contactToUpdate);
        }

        public bool Delete(int id)
        {
            return _contactRepo.Delete(id);    
        }
    }
}
