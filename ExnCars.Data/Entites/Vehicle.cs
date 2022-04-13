using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Data.Entites
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string VIN { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime InspectionvalidUntil { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public int ModelID { get; set; }
        public Model Model { get; set; }
        public IList<User> Users { get; set; }



    }
}
