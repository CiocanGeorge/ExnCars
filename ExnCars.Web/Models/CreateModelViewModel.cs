using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExnCars.Web.Models
{
    public class CreateModelViewModel
    {
        public int? SelectedBrandID { get; set; }
        public List<SelectListItem> Brands { get; set; }
    }
}
