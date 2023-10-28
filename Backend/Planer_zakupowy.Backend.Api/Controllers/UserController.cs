using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost]
        [Route("actions/register")]
        public string Register([FromBody] RegisterUserRequestModel registrationRequestModel)
        {
            _validator.ValidateInputData(registrationRequestModel.Email, registrationRequestModel.Password);
            var registeredUser = _userService.Register(registrationRequestModel.Email, registrationRequestModel.Password);

            return _userFactory.CreateUserSnapshot(registeredUser);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("actions/login")]
        public string Login([FromBody] LoginUserFromRequestModel loginRequestModel)
        {
            _validator.ValidateInputData(loginRequestModel.Email, loginRequestModel.Password);
            var loggedUser = _userService.Login(loginRequestModel.Email, loginRequestModel.Password);

            return _userFactory.CreateToken(loggedUser);
        }
    }
}
