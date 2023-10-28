using Planer_zakupowy.Backend.Domain.Entities;

namespace Planer_zakupowy.Backend.Api.Factories.Interfaces
{
    public interface IUserFactory
    {
        string CreateUserSnapshot(User user);
        string CreateToken(User user);
    }
}
