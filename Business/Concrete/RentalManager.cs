using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        RentalValidator rentalValidator = new RentalValidator();
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Rent(Rental rental)
        {
            //TODO: Review here
            var tempCar = _rentalDal.GetAll().FindLast(r => r.CarId == rental.CarId);
            var result = rentalValidator.Validate(rental);
            
            if(tempCar == null || tempCar?.ReturnDate != null && result.IsValid)
            {
                _rentalDal.Add(rental);
                return new SuccessfulResult(Messages<Rental>.CarRented);
            }
            return new ErrorResult(Messages<Rental>.CarUnavaible);
        }
        public IResult Cancel(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessfulResult(Messages<Rental>.Deleted);
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessfulDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        public IResult Update(Rental rental)
        {
            var result = rentalValidator.Validate(rental);
            if(result.IsValid == true)
            {
                _rentalDal.Update(rental);
                return new SuccessfulResult(Messages<Rental>.Updated);
            }
            return new ErrorResult();
        }
    }
}
