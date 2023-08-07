namespace Planer_zakupowy.Backend.Domain.Entities
{
    public class User
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }

        public User(Guid id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public User(string email, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
        }
    }
}
