using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryDalTest();
            EfDalTest();
        }

        private static void InMemoryDalTest()
        {
            List<Car> carsList = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 150, Description = "Subaru Impreza", ModelYear = 2007, Status = "Booked"},
                new Car{CarId = 2, BrandId = 2, ColorId = 6, DailyPrice = 180, Description = "Ford Fiesta", ModelYear = 2015, Status = "Avaible"},
                new Car{CarId = 3, BrandId = 4, ColorId = 3, DailyPrice = 165, Description = "Toyota Corolla", ModelYear = 2012, Status = "Booked"},
                new Car{CarId = 4, BrandId = 3, ColorId = 2, DailyPrice = 120, Description = "Ford Fiesta", ModelYear = 2010, Status = "Avaible"}
            };

            ICarService carManager = new CarManager(new InMemoryCarDal(carsList));

            Car car1 = new Car { CarId = 5, BrandId = 1, ColorId = 7, DailyPrice = 280, Description = "Nissan Qashqai", ModelYear = 2016, Status = "Booked" };
            
            Console.WriteLine("Initial list of cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nAdding {0} to inventory \n", car1.Description);
            carManager.Add(car1);
            
            Console.WriteLine("List of cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nRemoving {0} from inventory \n", car1.Description);
            carManager.Delete(car1);

            Console.WriteLine("List of cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
        private static void EfDalTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car {BrandId = 10, ColorId = 7, DailyPrice = 1250, Description = "Ferrari F430", ModelYear = 2005, Status = "Avaible" };

            Console.WriteLine("\nInitial records of Cars table:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nAdding {0} to Cars table \n", car1.Description);
            carManager.Add(car1);

            Console.WriteLine("List of cars:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nRemoving {0} from Cars table \n", car1.Description);
            carManager.Delete(car1);

            Console.WriteLine("List of records in Cars table:");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nList of cars with BMW brand:");
            foreach (Car car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nList of silver cars:");
            foreach (Car car in carManager.GetCarsByColorId(10))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nCar with id 1 is: {0}", carManager.GetCarById(1).Description);
        }
    }
}
