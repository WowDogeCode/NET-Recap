using Business.Abstract;
using Business.Concrete;
using Business.Constants;
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
            InMemoryDalTest();
            EfCarDalTest();
            EfColorDalTest();
            EfBrandDalTest();
            EfCustomerDalTest();
            EfUserDalTest();
            EfRentalDalTest();
        }

        private static void InMemoryDalTest()
        {
            List<Car> carsList = new List<Car>
            {
                new Car{ CarId = 1, BrandId = 1, ColorId = 1, CarName = "Subaru Impreza", DailyPrice = 150, Description = "Subaru Impreza", ModelYear = 2007 },
                new Car{ CarId = 2, BrandId = 2, ColorId = 4, CarName = "Ford Fiesta", DailyPrice = 180, Description = "Ford Fiesta", ModelYear = 2015 },
                new Car{ CarId = 3, BrandId = 4, ColorId = 3, CarName = "Toyota Corolla", DailyPrice = 165, Description = "Toyota Corolla", ModelYear = 2012 },
                new Car{ CarId = 4, BrandId = 3, ColorId = 2, CarName = "Honda Accord", DailyPrice = 120, Description = "Honda Accord", ModelYear = 2010 }
            };

            ICarService carManager = new CarManager(new InMemoryCarDal(carsList));

            Car car1 = new Car { CarId = 5, BrandId = 1, ColorId = 7, CarName = "Nissan Qashqai", DailyPrice = 280, Description = "Nissan Qashqai", ModelYear = 2016 };

            Console.WriteLine("Initial list of cars: \n");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nAdding {0} to inventory \n", car1.CarName);
            carManager.Add(car1);

            Console.WriteLine("List of cars: \n");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nRemoving {0} from inventory \n", car1.CarName);
            carManager.Delete(car1);

            Console.WriteLine("List of cars: \n");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nCar details are as follows: ");
            foreach (CarDetailDto car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car name: {0}, Brand: {1}, Color: {2}, Daily price: {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
        private static void EfCarDalTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { BrandId = 10, ColorId = 7, CarName = "Ferrari F430", DailyPrice = 1250, Description = "Ferrari F430", ModelYear = 2005 };

            Console.WriteLine("\nInitial records of Cars table:");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nAdding {0} to Cars table \n", car1.CarName);
            carManager.Add(car1);

            Console.WriteLine("List of cars:");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nRemoving {0} from Cars table \n", car1.CarName);
            carManager.Delete(car1);

            Console.WriteLine("List of records in Cars table:");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nList of cars with BMW brand:");
            foreach (Car car in carManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nList of silver cars:");
            foreach (Car car in carManager.GetCarsByColorId(10).Data)
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("\nCar with id 1 is: {0}", carManager.GetCarById(1).Data.CarName);

            Console.WriteLine("\nCar details are as follows: ");
            foreach (CarDetailDto car in carManager.GetCarDetails().Data)
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
            foreach (Color color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("\nAdding color: {0} to Colors table", color1.ColorName);
            colorManager.Add(color1);

            Console.WriteLine("\nList of colors: ");
            foreach (Color color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("\nRemoving color: {0} from Colors table", color1.ColorName);
            colorManager.Delete(color1);

            Console.WriteLine("\nList of colors: ");
            foreach (Color color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("\nColor with id 1 is: {0}", colorManager.GetById(1).Data.ColorName);
        }
        private static void EfBrandDalTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand()
            {
                BrandName = "Scania"
            };

            Console.WriteLine("\nInitial records of Brands table: ");
            foreach (Brand brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("\nAdding brand: {0} to Brands table", brand1.BrandName);
            brandManager.Add(brand1);

            Console.WriteLine("\nList of brands: ");
            foreach (Brand brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("\nRemoving brand: {0} from Brands table", brand1.BrandName);
            brandManager.Delete(brand1);

            Console.WriteLine("\nList of brands: ");
            foreach (Brand brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("\nBrand with id 1 is: {0}", brandManager.GetById(1).Data.BrandName);
        }
        private static void EfCustomerDalTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer1 = new Customer()
            {
                CompanyName = "Google",
                UserId = 4

            };

            Console.WriteLine("\nInitial records of Customers table: ");
            foreach (Customer customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }

            Console.WriteLine("\nAdding customer: {0} to Customers table", customer1.CompanyName);
            customerManager.Add(customer1);

            Console.WriteLine("\nList of customers: ");
            foreach (Customer customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }

            Console.WriteLine("\nRemoving customer: {0} from Customers table", customer1.CompanyName);
            customerManager.Delete(customer1);

            Console.WriteLine("\nList of customers: ");
            foreach (Customer customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }
        private static void EfUserDalTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            User user1 = new User()
            {
                Email = "john.doe@google.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "123123"
            };

            Console.WriteLine("\nInitial records of Users table: ");
            foreach (User user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName.Trim() + " " + user.LastName.Trim());
            }

            Console.WriteLine("\nAdding user: {0} {1} to Users table", user1.FirstName.Trim(), user1.LastName.Trim());
            userManager.Add(user1);

            Console.WriteLine("\nList of users: ");
            foreach (User user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName.Trim() + " " + user.LastName.Trim());
            }

            Console.WriteLine("\nRemoving user: {0} {1} from Users table", user1.FirstName.Trim(), user1.LastName.Trim());
            userManager.Delete(user1);

            Console.WriteLine("\nList of users: ");
            foreach (User user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName.Trim() + " " + user.LastName.Trim());
            }
        }
        private static void EfRentalDalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental
            {
                CarId = 1,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = null
            };

            Rental rental2 = new Rental
            {
                CarId = 2,
                CustomerId = 3,
                RentDate = DateTime.Now,
                ReturnDate = null
            };

            Console.WriteLine("\nRent records in Rentals table: ");
            foreach (Rental rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Rented at {0}", rental.RentDate);
            }
            
            Console.WriteLine("\nTrying to rent a booked car.");
            rentalManager.Rent(rental1);

            Console.WriteLine("\nTrying to rent an avaible car.");
            rentalManager.Rent(rental2);

            Console.WriteLine("\nRent records in Rentals table: ");
            foreach (Rental rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Rented at {0}", rental.RentDate);
            }
            
            Console.WriteLine("\nCancelling a rental.");
            rentalManager.Cancel(rental2);

            Console.WriteLine("\nRent records in Rentals table: ");
            foreach (Rental rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Rented at {0}", rental.RentDate);
            }
        }
    }
}
