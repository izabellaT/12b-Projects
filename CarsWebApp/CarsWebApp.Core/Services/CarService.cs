using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarsWebApp.Core.Contracts;
using CarsWebApp.Infrastructure.Data;
using CarsWebApp.Infrastructure.Data.Domain;

namespace CarsWebApp.Core.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string regNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price)
        {
            Car item = new Car
            {
                RegNumber = regNumber,
                Manufacturer = Manufacturer,  
                Model = Model,
                Picture = Picture,
                YearOfManufacture = YearOfManufacture,
                Price = Price
            };
            _context.Cars.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Find(carId);
        }

        public List<Car> GetCars()
        {
            List<Car> cars = _context.Cars.ToList();
            return cars;
        }

        public List<Car> GetCars(string searchStringModel, string searchStringPrice)
        {
            List<Car> cars = _context.Cars.ToList();
            if (!String.IsNullOrEmpty(searchStringModel) && !String.IsNullOrEmpty(searchStringPrice))
            {
                cars = cars.Where(d => d.Model.Contains(searchStringModel) && d.Price.ToString().Contains(searchStringPrice)).ToList();      
            }
            else if (!String.IsNullOrEmpty(searchStringModel))
            {
                cars = cars.Where(d => d.Model.Contains(searchStringModel)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringPrice))
            {
                cars = cars.Where(d => d.Price.ToString().Contains(searchStringPrice)).ToList();
            }
            return cars;
        }

        public List<Car> SortCars(string priceUp)
        {
            List<Car> cars = _context.Cars.ToList();
    
           if (!String.IsNullOrEmpty(priceUp))
            {
                cars.Sort();
            }
            return cars;
        }

        public bool RemoveById(int carId)
        {
            var car = GetCarById(carId);
            if (car == default(Car))
            {
                return false;
            }
            _context.Remove(car);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateCar(int carId, string regNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price)
        {
            var car = GetCarById(carId);
            if (car == default(Car))
            {
                return false;
            }

           car.RegNumber = regNumber;
            car.Manufacturer = Manufacturer;
            car.Model = Model;
            car.Picture = Picture;
            car.YearOfManufacture = YearOfManufacture;
            car.Price = Price;

            _context.Update(car);
            return _context.SaveChanges() != 0;
        }
    }
}
