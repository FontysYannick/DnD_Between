using Interface_DnD.DTO;

namespace Interface_DnD.Interface
{
    public interface IUser
    {
        UserDTO AttemptLogin(UserDTO userDTO);
        bool Register(UserDTO userDTO);

    }
}
