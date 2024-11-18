using Domain.Interfaces;
using Domain.Mapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserBeheer : IUserBeheer
    {

        private readonly UserRepository userRepository = new UserRepository();

        public void VoegGebruikerToe(int userId, string naam)
        {
            var user = new User (userId, naam);
            var userDTO = UserMapper.MapToDTO(user); // Convert to UserDTO
            userRepository.VoegUserToe(userDTO);
        }

        public List<User> GetAllUsers()
        {
            var userDTOs = userRepository.HaalAlleUsersOp();
            var users = new List<User>();

            foreach (var dto in userDTOs)
            {
                users.Add(UserMapper.MapToUser(dto)); // Convert each to User
            }

            return users;
        }

        public void VerwijderGebruiker(int userId)
        {
            userRepository.VerwijderUser(userId);
        }


        public int GenereerId ()
        {
           return userRepository.GenereerNieweUserId();
        }
       

    }
}
