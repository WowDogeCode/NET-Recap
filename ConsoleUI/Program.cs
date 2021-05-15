using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryDalTest();
            EfCarDalTest();
            //EfColorDalTest();
            //EfBrandDalTest();
        }

        private static void InMemoryDalTest()
        {
            List<Car> carsList = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, CarName = "Subaru Impreza", DailyPrice = 150, Description = "Subaru Impreza", ModelYear = 2007, Status = "Booked"},
                new Car{CarId = 2, BrandId = 2, ColorId = 4, CarName = "Ford Fiesta", DailyPrice = 180, Description = "Ford Fiesta", ModelYear = 2015, Status = "Avaible"},
                new Car{CarId = 3, BrandId = 4, ColorId = 3, CarName = "Toyota Corolla", DailyPrice = 165, Description = "Toyota Corolla", ModelYear = 2012, Status = "Booked"},
                new Car{CarId = 4, BrandId = 3, ColorId = 2, CarName = "Honda Accord", DailyPrice = 120, Description = "Honda Accord", ModelYear = 2010, Status = "Avaible"}
            };

            ICarService carManager = new CarManager(new InMemoryCarDal(carsList));

            Car car1 = new Car { CarId = 5, BrandId = 1, ColorId = 7, CarName = "Nissan Qashqai", DailyPrice = 280, Description = "Nissan Qashqai", ModelYear = 2016, Status = "Booked" };

            Console.WriteLine("Initial list of cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nAdding {0} to inventory \n", car1.CarName);
            carManager.Add(car1);

            Console.WriteLine("List of cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nRemoving {0} from inventory \n", car1.CarName);
            carManager.Delete(car1);

            Console.WriteLine("List of cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nCar details are as follows: ");
            foreach (CarDetailDto car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car name: {0}, Brand: {1}, Color: {2}, Daily price: {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
        private static void EfCarDalTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { BrandId = 10, ColorId = 7, CarName = "Ferrari F430", DailyPrice = 1250, Description = "Ferrari F430", ModelYear = 2005, Status = "Avaible" };

            Console.WriteLine("\nInitial records of Cars table:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nAdding {0} to Cars table \n", car1.CarName);
            carManager.Add(car1);

            Console.WriteLine("List of cars:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nRemoving {0} from Cars table \n", car1.CarName);
            carManager.Delete(car1);

            Console.WriteLine("List of records in Cars table:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nList of cars with BMW brand:");
            foreach (Car car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nList of silver cars:");
            foreach (Car car in carManager.GetCarsByColorId(10))
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nCar with id 1 is: {0}", carManager.GetCarById(1).CarName);

            Console.WriteLine("\nCar details are as follows: ");
            foreach (CarDetailDto car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car name: {0}, Brand: {1}, Color: {2}, Daily price: {3}", car.CarName.Trim(), car.BrandName.Trim(), car.ColorName.Trim(), car.DailyPrice);
            }
        }
        private static void EfColorDalTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color1 = new Color()
            {
                ColorName = "Aqua"
            };

            Console.WriteLine("\nInitial records of Colors table: ");
            foreach (Color color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("\nAdding color: {0} to Colors table", color1.ColorName);
            colorManager.Add(color1);

            Console.WriteLine("\nList of colors: ");
            foreach (Color color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("\nRemoving color: {0} from Colors table", color1.ColorName);
            colorManager.Delete(color1);

            Console.WriteLine("\nList of colors: ");
            foreach (Color color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("\nCar with id 1 is: {0}", colorManager.GetById(1).ColorName);
        }
        private static void EfBrandDalTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand()
            {
                BrandName = "Scania"
            };

            Console.WriteLine("\nInitial records of Brands table: ");
            foreach (Brand brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("\nAdding brand: {0} to Brands table", brand1.BrandName);
            brandManager.Add(brand1);

            Console.WriteLine("\nList of brands: ");
            foreach (Brand brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("\nRemoving brand: {0} from Brands table", brand1.BrandName);
            brandManager.Delete(brand1);

            Console.WriteLine("\nList of brands: ");
            foreach (Brand brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("\nBrand with id 1 is: {0}", brandManager.GetById(1).BrandName);
        }
    }
}
