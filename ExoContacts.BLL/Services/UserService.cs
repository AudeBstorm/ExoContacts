using ExoContacts.DAL.Repositories;
using ExoContacts.Domain.Entities;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoContacts.BLL.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Login(string email, string password)
        {
            //Idéalement :
            //Verifier que email est rempli et non null
            //Vérifier que password est rempli et non null
            //string.IsNullOrWhiteSpace(email) 

            User? user = _userRepository.GetByMail(email);
            if(user != null)
            {
                if (Argon2.Verify(user.HashPwd, password))
                    return user;
                else return null;
            }
            return user;
        }

        public User? Register(User user)
        {
            //Idéalement :
            //Verifier que user.Email est rempli et non null
            //Vérifier que user.Password est rempli et non null
            //Vérifier que l'email n'est pas déjà présent en DB

            //Hashage du password avant insertion en DB
            user.HashPwd = Argon2.Hash(user.Password);
            user.Password = null;

            int userId = _userRepository.Add(user);
            return _userRepository.GetById(userId);
        }
    }
}
