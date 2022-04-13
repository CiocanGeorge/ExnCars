using ExnCars.Data;
using ExnCars.Data.Entites;
using ExnCars.Services.UserServices;
using ExnCars.Services.UserServices.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExnCars.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ExnCarsContext>(options =>
            {
                options.UseSqlServer(@"Data Source=DESKTOP-FU828I7\MSSQLSERVER01;Initial Catalog=ExnCars;Integrated Security=True");
            });
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            var serviceProvider = serviceCollection.BuildServiceProvider();


            var userService = serviceProvider.GetService<IUserService>();







            var email = "ciprian.popescu@expertnetwork.ro";
            //userService.RegisterUser(new UserDto
            //{
            //    FirstName = "Ciprian2",
            //    LastName = "Popescu2",
            //    Email = email
            //});


            var user = userService.GetUserByEmail(email);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }
            else
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} ({user.Email})");
            }

            user.FirstName = "Cristian";
            user.LastName = "Ionescu";
            userService.UpdateUser(user);

            var user2 = userService.GetUserByEmail(email);

            if (user2 == null)
            {
                Console.WriteLine("User not found");
                return;
            }
            else
            {
                Console.WriteLine($"{user2.FirstName} {user2.LastName} ({user2.Email})");
            }
        }
    }
}
