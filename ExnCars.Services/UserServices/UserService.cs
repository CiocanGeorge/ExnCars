
using ExnCars.Data;
using ExnCars.Data.Entites;
using ExnCars.Services.UserServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExnCars.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public UserDto? GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            var user = userRepository.Query(u => u.Email == email).FirstOrDefault();
            if (user == null)
                return null;
            return new UserDto
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
        public void RegisterUser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (userRepository.Query(u => u.Email == user.Email).Any())
            {
                throw new Exception("Cannot insert user with the same email");
            }
            userRepository.Add(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
            unitOfWork.SaveChanges();
        }
        public void UpdateUser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var existingUser = userRepository.GetById(user.ID);
            if (existingUser == null)
            {
                throw new Exception("User was not found!");
            }

            if (userRepository.Query(u => u.Email == user.Email && u.ID != user.ID).Any())
            {
                throw new Exception("Cannot use an existing email!");
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            userRepository.Update(existingUser);
            unitOfWork.SaveChanges();
        }
        public List<UserDto> GetUsers()
        {
            return userRepository.GetAll().Select(x => new UserDto
            {
                ID=x.ID,
                Email=x.Email,
                FirstName=x.FirstName,
                LastName=x.LastName
            }).ToList();
        }

        public UserDto GetUserById(int id)
        {
            if (id < 1) throw new ArgumentException(nameof(id));

            var user= userRepository.GetById(id);
            if (user == null) return null;

            return new UserDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ID = user.ID
            };
        }

        public void Delete(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var existingUser = userRepository.GetById(user.ID);
            if (existingUser == null)
            {
                throw new Exception("User was not found!");
            }

            userRepository.Delete(existingUser);
            unitOfWork.SaveChanges();
        }
    }
}
