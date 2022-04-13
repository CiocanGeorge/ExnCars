using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Data.Entites
{
    public class Model
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FuelType { get; set; }
        public int EngineDisplacement { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
    }
}
