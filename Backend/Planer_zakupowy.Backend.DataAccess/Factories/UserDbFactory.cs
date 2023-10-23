using Planer_zakupowy.Backend.DataAccess.Factories.Interfaces;
using Planer_zakupowy.Backend.Domain.Entities;
using UserDb = Planer_zakupowy.Backend.DataAccess.Models.User;

namespace Planer_zakupowy.Backend.DataAccess.Factories
{
    public class UserDbFactory : IUserDbFactory
    {
        public User Create(UserDb userDb)
        {
            return new User(userDb.Id, userDb.Email, userDb.Password);
        }
    }
}
