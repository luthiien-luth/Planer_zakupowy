using Planer_zakupowy.Backend.Application.Repositories;
using Planer_zakupowy.Backend.DataAccess.Factories.Interfaces;
using Planer_zakupowy.Backend.Domain.Entities;
using UserDb = Planer_zakupowy.Backend.DataAccess.Models.User;

namespace Planer_zakupowy.Backend.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PlanerZakupowyDbContext _context;
        private readonly IUserDbFactory _factory;

        public UserRepository(PlanerZakupowyDbContext context, IUserDbFactory factory)
        {
            _context = context;
            _factory = factory;
        }
       
        public User? GetOrDefault(string email)
        {
            var userDb = _context.Users
                .FirstOrDefault(u => u.Email == email);

            if (userDb == default)
            {
                return default;
            }

            return _factory.Create(userDb);
        }

        public User Register(User user)
        {
            var userDb = new UserDb()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password
            };

            _context.Users.Add(userDb);
            _context.SaveChanges();

            return user;
        }

        public bool CheckPasswordForUser(string email, string password)
        {
            var userDb = _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if(userDb == default)
            {
                return false;
            }

            return true;
        }
    }
}
