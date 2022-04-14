using ExnCars.Services.Brands;
using ExnCars.Services.Brands.Dto;
using ExnCars.Services.Models;
using ExnCars.Services.Models.Dto;
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
        private readonly IModelService modelService;
        public ModelsController(IBrandService brandService, IModelService modelService)
        {
            this.brandService = brandService;
            this.modelService = modelService;
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
            var modelDto = new ModelDto
            {
                Name = createModelViewModel.Name,
                FuelType = createModelViewModel.FuelType,
                EngineDisplacement = createModelViewModel.EngineDisplacement,
                BrandID = createModelViewModel.SelectedBrandID.Value

            };
            modelService.CreateModel(modelDto);
            return RedirectToAction("Index", "Users");
        }
    }
}
