using ExnCars.Services.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Services.Models
{
    public interface IModelService
    {
        void CreateModel(ModelDto modelDto);
    }
}
