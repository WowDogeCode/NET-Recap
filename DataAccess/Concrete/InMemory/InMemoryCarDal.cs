using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal(List<Car> cars)
        {
            _cars = cars;
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

        public Car GetById(Expression<Func<Car, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> expression = null)
        {
            return expression == null
                ? _cars.ToList()
                : throw new NotImplementedException();
        }
        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }
        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
        public List<CarDetailDto> GetCarDetails()
        {
            List<Color> colors = new List<Color>()
            {
                new Color{ColorId = 1, ColorName = "Black"},
                new Color{ColorId = 2, ColorName = "Red"},
                new Color{ColorId = 3, ColorName = "Blue"},
                new Color{ColorId = 4, ColorName = "Brown"}
            };

            List<Brand> brands = new List<Brand>()
            {
                new Brand{BrandId = 1, BrandName = "Subaru"},
                new Brand{BrandId = 2, BrandName = "Ford"},
                new Brand{BrandId = 3, BrandName = "Honda"},
                new Brand{BrandId = 4, BrandName = "Toyota"}
            };

            var result = from car in _cars
                         join color in colors
                         on car.ColorId equals color.ColorId
                         join brand in brands
                         on car.BrandId equals brand.BrandId
                         select new CarDetailDto
                         {
                             CarName = car.CarName,
                             ColorName = color.ColorName,
                             BrandName = brand.BrandName,
                             DailyPrice = car.DailyPrice
                         };
            return result.ToList();
        }
    }
}
