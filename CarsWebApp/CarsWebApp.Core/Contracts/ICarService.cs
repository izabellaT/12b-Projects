using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarsWebApp.Infrastructure.Data.Domain;

namespace CarsWebApp.Core.Contracts
{
    public interface ICarService
    {
        bool Create(string regNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price);
        bool UpdateCar(int carId, string regNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price);
        List<Car> GetCars();
        Car GetCarById(int carId);
        bool RemoveById(int carId);
        List<Car> GetCars(string searchStringModel, string seatchStringPrice);

        List<Car> SortCars(string priceUp);
    }
}
