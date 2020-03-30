using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspBaza.Data.Interfaces;
using aspBaza.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace aspBaza.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.Id == carId);
    }
}
