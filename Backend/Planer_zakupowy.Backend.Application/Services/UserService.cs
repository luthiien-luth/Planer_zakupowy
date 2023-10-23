using Planer_zakupowy.Backend.Application.Exceptions;
using Planer_zakupowy.Backend.Application.Interfaces;
using Planer_zakupowy.Backend.Application.Repositories;
using Planer_zakupowy.Backend.Domain.Entities;

namespace Planer_zakupowy.Backend.Application.Services
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
            {
                throw new InvalidDataProvidedException($"Użytkownik z emailem {email} już istnieje.");
            }

            var registeredUser = new User(email, password);
            _userRepository.Register(registeredUser);

            return registeredUser;
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.GetOrDefault(email); 

            if (user == default)
            {
                throw new InvalidDataProvidedException($"Nie istnieje użytkownik z emailem {email}");
            }

            if (!_userRepository.CheckPasswordForUser(email, password))
            {
                throw new InvalidDataProvidedException("Podane hasło jest nieprawidłowe.");
            }

            return user;
        }
    }
}
