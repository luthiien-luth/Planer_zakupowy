using Newtonsoft.Json;
using Planer_zakupowy.Backend.Api.Factories.Interfaces;
using Planer_zakupowy.Backend.Domain.Entities;

namespace Planer_zakupowy.Backend.Api.Factories
{
    public class UserFactory : IUserFactory
    {
        public string Create(User user)
        {
            var responseUser = JsonConvert.SerializeObject(user);

            return responseUser;
        }
    }
}
