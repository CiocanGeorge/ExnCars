using ExnCars.Services.UserServices.Dto;
using System.Collections.Generic;

namespace ExnCars.Services.UserServices
{
    public interface IUserService
    {
        UserDto GetUserByEmail(string email);
        List<UserDto> GetUsers();
        void RegisterUser(UserDto user);
        void UpdateUser(UserDto user);
        UserDto GetUserById(int id);
        void Delete(UserDto user);
    }
}