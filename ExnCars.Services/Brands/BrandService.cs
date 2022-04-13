using ExnCars.Data;
using ExnCars.Data.Entites;
using ExnCars.Services.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Services.Brands
{
    public class BrandService:IBrandService
    {
        private readonly IRepository<Brand> brandRepository;
        public BrandService(IRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public List<BrandDto> GetAllBrands()
        {
            var brands = brandRepository.GetAll();

            return brands.Select(x => new BrandDto
            {
                ID=x.ID,
                Name=x.Name,
                Logo=x.Logo
            }).ToList();
            
        }

    }
}
