using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("List of avaible cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Car car1 = new Car()
            {
                CarId = 7,
                ColorId = 6,
                BrandId = 7,
                DailyPrice = 430,
                Description = "Maserati GranTurismo",
                ModelYear = 2009
            };

            carManager.Add(car1);

            Console.WriteLine("Car with the id 7 is: {0} \n", carManager.GetById(7).Description); 

            Console.WriteLine("List of avaible cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Delete(car1);

            Console.WriteLine("List of avaible cars: \n");
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }
    }
}
