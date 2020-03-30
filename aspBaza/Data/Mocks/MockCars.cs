using aspBaza.Data.Interfaces;
using aspBaza.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspBaza.Data.Mocks
{
    public class MockCars:IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> cars
        {
            get
            {
                return new List<Car>
                {
                    new Car{
                        Name="Tesla",
                        ShortDesc="коротное опасание теслы",
                        LongDesc="длинное описание теслы",
                        Img="/img/tesla.jpg",
                        price=4500,
                        IsFavourite=true,
                        Available=true,
                        Category=_categoryCars.allCategorys.First()
                    },

                    new Car{
                        Name="Ford",
                        ShortDesc="коротное опасание форда",
                        LongDesc="длинное описание форда",
                        Img="/img/ford.jpg",
                        price=3000,
                        IsFavourite=false,
                        Available=true,
                        Category=_categoryCars.allCategorys.Last()
                    },

                    new Car{
                        Name="Mazda",
                        ShortDesc="коротное опасание мазды",
                        LongDesc="длинное описание мазды",
                        Img="/img/mazda.png",
                        price=4000,
                        IsFavourite=true,
                        Available=true,
                        Category=_categoryCars.allCategorys.Last()},

                    new Car{
                        Name="Fiat",
                        ShortDesc="коротное опасание фиата",
                        LongDesc="длинное описание фиата",
                        Img="/img/fiat.jpg",
                        price=1000,
                        IsFavourite=false,
                        Available=false,
                        Category=_categoryCars.allCategorys.Last()}
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
