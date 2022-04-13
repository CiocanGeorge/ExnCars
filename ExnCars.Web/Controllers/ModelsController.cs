using ExnCars.Services.Brands;
using ExnCars.Services.Brands.Dto;
using ExnCars.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExnCars.Web.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IBrandService brandService;
        public ModelsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            var brandDtos = brandService.GetAllBrands() ?? new List<BrandDto>();

            var createModelViewModel = new CreateModelViewModel
            {
                SelectedBrandID = null,
                Brands = brandDtos.Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList()
            };
            
            return View(createModelViewModel);
        }
        [HttpPost]
        public IActionResult Create([FromForm]CreateModelViewModel createModelViewModel)
        {
            return RedirectToAction("Index", "Users");
        }
    }
}
