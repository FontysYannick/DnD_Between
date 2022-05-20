using Interface_DnD.DTO;
using Interface_DnD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub_DnD.Stub
{
    public class UserStub : IUser
    {
        public List<UserDTO> UserList { get; set; }

        public UserStub()
        {
            this.UserList = new List<UserDTO>()
            {
                new UserDTO{ Id = 1, Username = "Yannick", Password = "Test123"},
                new UserDTO{ Id = 2, Username = "Billy", Password = "BingBong" },
            };
        }

        public UserDTO AttemptLogin(UserDTO userDTO)
        {
            for (var i = 0; i < UserList.Count; i++)
            {
                if (UserList[i].Username == userDTO.Username)
                {
                    if (UserList[i].Password == userDTO.Password)
                    {
                        return userDTO;
                    }
                }
            }
            return default;
        }

        public bool Register(UserDTO userDTO)
        {
            for (var i = 0; i < UserList.Count; i++)
            {
                if (UserList[i].Username != userDTO.Username)
                {
                    UserList.Add(userDTO);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
