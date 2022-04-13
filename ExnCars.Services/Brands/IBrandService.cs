using ExnCars.Services.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Services.Brands
{
    public interface IBrandService
    {
        List<BrandDto> GetAllBrands();
    }
}
