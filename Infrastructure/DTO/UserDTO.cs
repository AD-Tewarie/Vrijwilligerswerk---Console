using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Naam { get; set; }



        public UserDTO(int userId, string naam)
        {
            UserId = userId;
            Naam = naam;
        }


    }
}
