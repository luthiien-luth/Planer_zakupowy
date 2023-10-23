using Planer_zakupowy.Backend.Domain.Entities;
using UserDb = Planer_zakupowy.Backend.DataAccess.Models.User;

namespace Planer_zakupowy.Backend.DataAccess.Factories.Interfaces
{
    public interface IUserDbFactory
    {
        User Create(UserDb userDb);
    }
}
