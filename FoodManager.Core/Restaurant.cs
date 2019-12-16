using System;
using System.Collections.Generic;
using System.Text;

namespace FoodManager.Core
{
    public partial class Restaurant
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }

    }


}
