using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 150.35, ModelYear = 2012, Description = "Nissan Juke" },
                new Car{CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 180, ModelYear = 2014, Description = "BMW 3.16i" },
                new Car{CarId = 3, BrandId = 3, ColorId = 2, DailyPrice = 125, ModelYear = 2009, Description = "Volkswagen Polo" },
                new Car{CarId = 4, BrandId = 4, ColorId = 3, DailyPrice = 95.50, ModelYear = 2006, Description = "Opel Corsa" },
                new Car{CarId = 5, BrandId = 1, ColorId = 4, DailyPrice = 210.60, ModelYear = 2016, Description = "Nissan Qashqai" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public List<Car> GetAll()
        {
            return _cars.ToList();
        }
        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }
    }
}
