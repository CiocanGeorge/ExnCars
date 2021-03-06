using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExnCars.Web.Models
{
    public class CreateModelViewModel
    {
        public string Name { get; set; }
        public string FuelType { get; set; }
        public int EngineDisplacement { get; set; }
        public int? SelectedBrandID { get; set; }
        public List<SelectListItem> Brands { get; set; }
    }
}
