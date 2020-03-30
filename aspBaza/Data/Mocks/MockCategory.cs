using aspBaza.Data.Interfaces;
using aspBaza.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspBaza.Data.Mocks
{
    public class MockCategory:ICarsCategory
    {
        public IEnumerable<Category> allCategorys
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Электромобили", Desc="Современные машины на альтернативной энергии"},
                    new Category{CategoryName="Бензиновые авто", Desc="Машины с ДВС"}
                };
            }
        }
    }
}
