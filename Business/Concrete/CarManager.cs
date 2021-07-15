using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
            return new SuccessfulResult(Messages<Car>.Added);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessfulResult(Messages<Car>.Deleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessfulResult(Messages<Car>.Added);
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll());
        }
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }
        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessfulDataResult<Car>(_carDal.GetById(c => c.CarId == carId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessfulDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
