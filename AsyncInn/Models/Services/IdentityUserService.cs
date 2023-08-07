using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AsyncInn.Models.Services
{
    public class IdentityUserService : IUser
    {

        private UserManager<ApplicationUser> _userManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool validPassword = await _userManager.CheckPasswordAsync(user, password);

            if (validPassword)
            {
                return new UserDto { Id = user.Id, Username = user.UserName };
            }

            return null;
        }

        public async Task<UserDto> Register(RegisterUserDto registerUser, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerUser.Username,
                Email = registerUser.Email,
                PhoneNumber = registerUser.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);


            if (result.Succeeded)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerUser.Password) :
                               error.Code.Contains("Email") ? nameof(registerUser.Email) :
                               error.Code.Contains("Username") ? nameof(registerUser.Username) :
                               "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }
    }
}
