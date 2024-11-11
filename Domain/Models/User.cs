using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        

        public int UserId { get; set; }
        public string Naam { get; set; }

        public override string ToString()
        {
            return $"Gebruiker {UserId}: {Naam}";
        }

        public User(int userId, string naam)
        {
            UserId = userId;
            Naam = naam;
        }



    }
}
