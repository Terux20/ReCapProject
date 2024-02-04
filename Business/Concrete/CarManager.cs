using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using System.ComponentModel.DataAnnotations;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal) 
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Car>> CarDailyPrice()
        {
            _carDal.GetAll(c => c.DailyPrice > 0);
            return new SuccessDataResult<List<Car>>(Messages.ProductsListed);
        }

        public IDataResult<List<Car>> CarNameController()
        {
            _carDal.GetAll(c=>c.Description.Length>2);
            return new SuccessDataResult<List<Car>>(Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }


            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.MaintenanceTime);
            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ProductsListed);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.ProductsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.ProductsListed);
        }
    }
}
