﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Delete(int carImageId);
        IResult Update(CarImage carImage);
        IDataResult<List<CarImage>> GetCarImages();
    }
}
