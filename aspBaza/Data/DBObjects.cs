using aspBaza.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspBaza.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
          

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla",
                        ShortDesc = "коротное опасание теслы",
                        LongDesc = "длинное описание теслы",
                        Img = "/img/tesla.jpg",
                        price = 4500,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },

                    new Car
                    {
                        Name = "Ford",
                        ShortDesc = "коротное опасание форда",
                        LongDesc = "длинное описание форда",
                        Img = "/img/ford.jpg",
                        price = 3000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Бензиновые авто"]
                    },

                    new Car
                    {
                        Name = "Mazda",
                        ShortDesc = "коротное опасание мазды",
                        LongDesc = "длинное описание мазды",
                        Img = "/img/mazda.png",
                        price = 4000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Бензиновые авто"]
                    },

                    new Car
                    {
                        Name = "Fiat",
                        ShortDesc = "коротное опасание фиата",
                        LongDesc = "длинное описание фиата",
                        Img = "/img/fiat.jpg",
                        price = 1000,
                        IsFavourite = false,
                        Available = false,
                        Category = Categories["Бензиновые авто"]
                    }
                );
            }

            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{CategoryName="Электромобили", Desc="Современные машины на альтернативной энергии"},
                        new Category{CategoryName="Бензиновые авто", Desc="Машины с ДВС"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                    {
                        category.Add(el.CategoryName,el);
                    }
                }
                return category;
            }
        }
    }
}
