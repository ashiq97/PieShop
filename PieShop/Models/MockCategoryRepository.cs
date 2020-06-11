﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Fruite Pies",Description="All Fruite Pies"},
                new Category{CategoryId=2,CategoryName="Cheese cakes",Description="Cheesy all the way"},
                new Category{CategoryId=3,CategoryName="Seasonal pies",Description="Get in mod for a seasonal pie"}
            };
    }
}
