using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace AsyncInn.Models.Services
{
    public class IdentityUserService : IUser
    {

        private UserManager<ApplicationUser> _userManager;
        private JwtTokenService tokenService;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtTokenService tokenService)
        {
            _userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool validPassword = await _userManager.CheckPasswordAsync(user, password);

            if (validPassword)
            {
                return new UserDto { Id = user.Id, Username = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
                };
            }

            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);

            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
            };
        }


        public async Task<UserDto> Register(RegisterUserDto registerUser, ModelStateDictionary modelState, ClaimsPrincipal User)
        {

            bool isDistrictManager = User.IsInRole("District Manager");
            bool isPropertyManager = User.IsInRole("Property Manager");

            if (isDistrictManager || (isPropertyManager && registerUser.Roles.Contains("Agent")))
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
                    if (isDistrictManager)
                    {
                        await _userManager.AddToRolesAsync(user, registerUser.Roles);
                    }
                    else if (isPropertyManager && registerUser.Roles.Contains("Agent"))
                    {
                        await _userManager.AddToRolesAsync(user, new[] { "Agent" });
                    }

                    return new UserDto()
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5)),
                        Roles = await _userManager.GetRolesAsync(user)
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
            else
            {
                modelState.AddModelError("", "You don't have permission to create this type of account.");
                return null;
            }
        }
            
    }
}
