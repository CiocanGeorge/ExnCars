using ExnCars.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Services.Models.Dto
{
    public class ModelDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FuelType { get; set; }
        public int EngineDisplacement { get; set; }
        public int BrandID { get; set; }
    }
}
