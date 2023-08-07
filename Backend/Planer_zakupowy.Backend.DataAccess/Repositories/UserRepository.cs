using Planer_zakupowy.Backend.Domain.Entities;
using Planer_zakupowy.Backend.Domain.Repositories;
using UserDb = Planer_zakupowy.Backend.DataAccess.Models.User;

namespace Planer_zakupowy.Backend.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Planer_zakupowyDbContext _context;

        public UserRepository(Planer_zakupowyDbContext context)
        {
            _context = context;
        }

        public User? GetOrDefault(string email)
        {
            var userDb = _context.Users
                .FirstOrDefault(u => u.Email == email);

            if (userDb == default)
                return default;

            var user = new User(userDb.Id, userDb.Email, userDb.Password);

            return user;
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
    }
}
