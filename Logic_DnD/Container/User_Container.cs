using Interface_DnD.DTO;
using Interface_DnD.Interface;
using Logic_DnD.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_DnD.Container
{
    public class User_Container
    {
        private IUser _IUser;
        public User_Container(IUser user)
        {
            this._IUser = user;
        }

        public User attemptLogin(string username, string password)
        {
            UserDTO userDTO = new UserDTO() { Id = 0, Username = username, Password = password };
            UserDTO DTO = _IUser.AttemptLogin(userDTO);
            User user = new User(DTO.Id, DTO.Username, DTO.Password);

            return user;
        }

        public bool register(string username, string password)
        {
            UserDTO userDTO = new UserDTO() {Id = 0, Username =  username, Password = password};
            return _IUser.Register(userDTO);
        }
    }
}
