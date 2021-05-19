using Business.Abstract;
using Business.Constants;
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
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Rent(Rental rental)
        {
            var tempCar = _rentalDal.GetAll().FindLast(r => r.CarId == rental.CarId);

            if(tempCar == null || tempCar?.ReturnDate != null)
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
            _rentalDal.Update(rental);
            return new SuccessfulResult(Messages<Rental>.Updated);
        }
    }
}
