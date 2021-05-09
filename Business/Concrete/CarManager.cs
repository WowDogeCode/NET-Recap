using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        //ToDo: Add business logic in CarManager
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            Console.WriteLine("Adding: {0} \n", car.Description);
            _carDal.Add(car);
        }
        public void Delete(Car car)
        {
            Console.WriteLine("Deleting: {0} \n", car.Description);
            _carDal.Delete(car);
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }
    }
}
