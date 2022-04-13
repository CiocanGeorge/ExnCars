using System;
using System.Collections.Generic;

namespace ExnCars.Data.Entites
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }

    }
}
