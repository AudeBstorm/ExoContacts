using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoContacts.DAL.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? NickName { get; set; }
        public string  Mail { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ContactType { get; set; }
    }
}
