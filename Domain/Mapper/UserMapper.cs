using Domain.Models;
using Infrastructure.Repos;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Domain.Mapper
{
    internal class UserMapper
    {
        private static UserRepository UserRepo = new UserRepository();


        public static User MapToUser(UserDTO dto)
        {
            return new User(
                dto.UserId,
                dto.Naam


                );
        }

        internal static UserDTO MapToDTO(User user)
        {
            return new UserDTO(
                user.UserId,
                user.Naam
                );
        }
    }
}
