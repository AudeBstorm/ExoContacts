using ExoContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoContacts.DAL.Repositories
{
    public class ContactRepository
    {
        private string _connectionString = "server=DESKTOP-SUVSSH1;Database=ExoContact;integrated security=true";

        //READ
        public IEnumerable<Contact> GetAll()
        {
            //Connection à la DB + Création de la commande SQL
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Contact";

            //On créer la liste dans laquelle on va ajouter chacun des contacts
            List<Contact> contacts = new List<Contact>();

            //On ouvre la connection
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Contact contactToAdd = new Contact()
                {
                    Id = (int)reader["Id"],
                    LastName = (string)reader["LastName"],
                    FirstName = (string)reader["FirstName"],
                    NickName = reader["NickName"] as string ?? null,
                    Mail = (string)reader["Mail"],
                    Phone = (string)reader["Tel"],
                    BirthDate = reader["BirthDate"] as DateTime? ?? null,
                    ContactType = (string)reader["ContactType"]
                };
                contacts.Add(contactToAdd);
            }

            connection.Close();
            //On renvoie la liste de contacts
            return contacts;
        }

        public Contact GetById(int id)
        {
            //Connection à la DB + Création de la commande SQL
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Contact WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);

            //On ouvre la connection
            connection.Open();

            Contact contact = new Contact();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                contact.Id = (int)reader["Id"];
                contact.LastName = (string)reader["LastName"];
                contact.FirstName = (string)reader["FirstName"];
                contact.NickName = reader["NickName"] as string ?? null ;
                contact.Mail = (string)reader["Mail"];
                contact.Phone = (string)reader["Tel"];
                contact.BirthDate = reader["BirthDate"] as DateTime? ?? null;
                contact.ContactType = (string)reader["ContactType"];
               
            }

            connection.Close();
            //On renvoie la liste de contacts
            return contact;
        }

        //CREATE
        public int Add(Contact contactToAdd)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Contact(LastName, FirstName, NickName, Mail, Tel, BirthDate, ContactType)" +
            " OUTPUT inserted.Id "+
            " VALUES (@lastname, @firstname, @nickname, @mail, @phone, @birthdate, @contacttype)";
            cmd.Parameters.AddWithValue("lastname", contactToAdd.LastName);
            cmd.Parameters.AddWithValue("firstname", contactToAdd.FirstName);
            cmd.Parameters.AddWithValue("nickname", contactToAdd.NickName is null ? DBNull.Value : contactToAdd.NickName);
            cmd.Parameters.AddWithValue("mail", contactToAdd.Mail);
            cmd.Parameters.AddWithValue("phone", contactToAdd.Phone);
            cmd.Parameters.AddWithValue("birthdate", contactToAdd.BirthDate is null ? DBNull.Value : contactToAdd.BirthDate);
            cmd.Parameters.AddWithValue("contacttype", contactToAdd.ContactType);

            connection.Open();
            int? id =(int?)cmd.ExecuteScalar();
            connection.Close();

            return id ?? -1;
        }

        //UPDATE
        public bool Update(int id, Contact contactToEdit)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Contact" +
                " SET LastName = @lastname, FirstName = @firstname, NickName = @nickname, Mail = @mail, Tel = @phone, BirthDate = @birthdate, ContactType = @contacttype" +
                " WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("lastname", contactToEdit.LastName);
            cmd.Parameters.AddWithValue("firstname", contactToEdit.FirstName);
            cmd.Parameters.AddWithValue("nickname", contactToEdit.NickName is null ? DBNull.Value : contactToEdit.NickName);
            cmd.Parameters.AddWithValue("mail", contactToEdit.Mail);
            cmd.Parameters.AddWithValue("phone", contactToEdit.Phone);
            cmd.Parameters.AddWithValue("birthdate", contactToEdit.BirthDate is null ? DBNull.Value : contactToEdit.BirthDate);
            cmd.Parameters.AddWithValue("contacttype", contactToEdit.ContactType);

            connection.Open();
            int nbRow = (int)cmd.ExecuteNonQuery();
            connection.Close();

            return nbRow == 1;
        }

        //DELETE
        public bool Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Contact WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", id);

            connection.Open();
            int nbRow = cmd.ExecuteNonQuery();
            connection.Close();

            return nbRow == 1;
        }
    }
}
