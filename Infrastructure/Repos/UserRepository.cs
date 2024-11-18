using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Infrastructure.Repos
{
    public class UserRepository
    {
        private readonly List<UserDTO> users = new List<UserDTO>();

        //premade users 

        UserDTO user1 = new UserDTO(1, "Jan Jansen");
        UserDTO user2 = new UserDTO(2, "Anna De Vries");
        UserDTO user3 = new UserDTO(3, "Piet Pietersen");
        UserDTO user4 = new UserDTO(4, "Merel Boeren");
        UserDTO user5 = new UserDTO(5, "Dirk Keizer");
        UserDTO user6 = new UserDTO(6, "Suzanne Peters");


        public UserRepository()
        {

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);
            users.Add(user6);
      
        }

        public UserDTO HaalUserOpId(int userId)
        {
            foreach (var user in users)
            {
                if (user.UserId == userId)
                {
                    return user;
                }
            }
            return null;
        }

        public void VoegUserToe(UserDTO user)
        {
            users.Add(user);

        }

        public List<UserDTO> HaalAlleUsersOp()
        {
            return users;   
        }

        public void VerwijderUser (int userId)
        {
            for (int i = 0; i < users.Count; i++) {
                if (users[i].UserId == userId)
                {
                    users.RemoveAt(i);
                    break;
                }
            }
        }

        public int GenereerNieweUserId()
        {
            int maxId = 0;
            foreach (var user in users)
            {
                if (user.UserId > maxId)
                {
                    maxId = user.UserId;
                }
            }
            return maxId + 1;
        }

    }
}
