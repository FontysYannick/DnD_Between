namespace Logic_DnD.Classes
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

    }
}
