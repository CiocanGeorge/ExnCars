using ExnCars.Data;
using ExnCars.Data.Entites;
using ExnCars.Services.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Services.Models
{
    public class ModelService: IModelService
    {
        private readonly IRepository<Model> modelRepository;
        private readonly IUnitOfWork unitOfWork;
        public ModelService(IRepository<Model> modelRepository, IUnitOfWork unitOfWork)
        {
            this.modelRepository = modelRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateModel(ModelDto modelDto)
        {
            if (modelDto == null) throw new ArgumentNullException(nameof(modelDto));

            var model = new Model
            {
                Name = modelDto.Name,
                BrandID = modelDto.BrandID,
                EngineDisplacement = modelDto.EngineDisplacement,
                FuelType = modelDto.FuelType
            };
            modelRepository.Add(model);
            unitOfWork.SaveChanges();

        }
    }
}
