using Planer_zakupowy.Backend.Domain.Entities;
using Planer_zakupowy.Backend.Domain.Exceptions;
using Planer_zakupowy.Backend.Domain.Interfaces;
using Planer_zakupowy.Backend.Domain.Repositories;

namespace Planer_zakupowy.Backend.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(string email, string password)
        {
            var user = _userRepository.GetOrDefault(email);

            if (user != default)
                throw new InvalidDataProvidedException($"Użytkownik z emailem {email} już istnieje.");

            var registeredUser = new User(email, password);
            _userRepository.Register(registeredUser);

            return registeredUser;
        }
    }
}
