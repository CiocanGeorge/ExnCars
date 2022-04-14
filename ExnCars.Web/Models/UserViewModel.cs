using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExnCars.Web.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        [MaxLength(20,ErrorMessage ="Firstname length invalide")]
        public string FirstName { get; set; }
        [MaxLength(20, ErrorMessage = "Firstname length invalide")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage ="Invalide email")]
        public string Email { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
