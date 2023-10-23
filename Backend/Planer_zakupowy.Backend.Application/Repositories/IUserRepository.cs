using Planer_zakupowy.Backend.Domain.Entities;

namespace Planer_zakupowy.Backend.Application.Repositories
{
    public interface IUserRepository
    {
        User? GetOrDefault(string email);
        User Register(User user);
        bool CheckPasswordForUser(string email, string password);
    }
}
