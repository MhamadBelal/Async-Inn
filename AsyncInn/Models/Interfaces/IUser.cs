using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AsyncInn.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Register(RegisterUserDto registerUser, ModelStateDictionary modelState);

        public Task<UserDto> Authenticate(string username, string password);
    }
}
