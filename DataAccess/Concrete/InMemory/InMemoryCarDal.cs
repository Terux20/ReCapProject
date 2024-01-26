﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal() 
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=2,DailyPrice=30000,Description="kırmızı bir lamborghini",ModelYear=2000},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=30000,Description="kırmızı bir lamborghini",ModelYear=2000},
                new Car{CarId=3,BrandId=2,ColorId=1,DailyPrice=50000,Description="mavi bir bugatti",ModelYear=2019},
                new Car{CarId=4,BrandId=2,ColorId=1,DailyPrice=50000,Description="mavi bir bugatti",ModelYear=2019},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var deleteId = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(deleteId);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
