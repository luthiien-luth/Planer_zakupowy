using Microsoft.AspNetCore.Mvc;
using Planer_zakupowy.Backend.Api.Factories.Interfaces;
using Planer_zakupowy.Backend.Api.RequestModels;
using Planer_zakupowy.Backend.Application.Interfaces;

namespace Planer_zakupowy.Backend.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserFactory _userFactory;
        private readonly IValidator _validator;

        public UserController(IUserService userService, IUserFactory userFactory, IValidator validator)
        {
            _userService = userService;
            _userFactory = userFactory;
            _validator = validator;
        }

        [HttpPost]
        [Route("actions/register")]
        public string Register([FromBody] RegisterUserRequestModel registerUser)
        {
            _validator.ValidateRegistrationData(registerUser.Email, registerUser.Password);
            var registeredUser = _userService.Register(registerUser.Email, registerUser.Password);

            var responseUser = _userFactory.Create(registeredUser);

            return responseUser;
        }
    }
}
