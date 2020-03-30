using aspBaza.Data.Interfaces;
using aspBaza.Data.Models;
using aspBaza.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspBaza.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;

        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars=null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.cars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i=> i.Id);
                }
                else if(string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.cars.Where(i => i.Category.CategoryName.Equals("Бензиновые авто")).OrderBy(i => i.Id);
                }

                currentCategory = _category;                
            }

            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                currentCategory = currentCategory
            };

            ViewBag.Title = "Страница с авто";
            //CarsListViewModel obj = new CarsListViewModel();
            //obj.AllCars = _allCars.cars;
            //obj.currentCategory = "Автомобили";
            return View(carObj);
        }
    }
}
