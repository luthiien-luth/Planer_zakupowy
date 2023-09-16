using Planer_zakupowy.Backend.Domain.Entities;

namespace Planer_zakupowy.Backend.Application.Interfaces
{
    public interface IUserService
    {
        User Register(string email, string password);
    }
}
