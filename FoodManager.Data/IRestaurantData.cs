using FoodManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodManager.Data
{
   public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetByName(string name);
        Restaurant GetByID(Guid id);

        bool Edit(Restaurant restaurant);

    }
    public class IMemoryRestaurantData : IRestaurantData
    {

        readonly List<Restaurant> restaurants;

        private Guid CreateUniqIdentity()
        {
            return Guid.NewGuid();
        }
        public IMemoryRestaurantData()
        {
            restaurants = new List<Restaurant> {
            new Restaurant { ID = CreateUniqIdentity(), Name = "Red Thi", Location="Hornsby",Cuisine = CuisineType.Thi },
            new Restaurant { ID = CreateUniqIdentity(), Name = "Cooks Garden", Location="Trummura",Cuisine = CuisineType.Australian },
            new Restaurant { ID = CreateUniqIdentity(), Name = "Jame Jam", Location="Hornsby",Cuisine = CuisineType.Iranian }

         };
        }


        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.Select(r => r).OrderBy(o => o.Name).ThenBy(t => t.Cuisine);
        }
        public IEnumerable<Restaurant> GetByName(string name)
        {
            return restaurants.Where(r => r.Name.StartsWith(name)).OrderBy(o => o.Name).ThenBy(t => t.Cuisine);
        }
        public Restaurant GetByID(Guid id)
        {
            return restaurants.SingleOrDefault(r => r.ID == id);
        }
        public bool Edit(Restaurant restaurant)
        {
           var r= restaurants.Single(res => res.ID == restaurant.ID);
            r.Name = restaurant.Name;
            r.Location = restaurant.Location;

            return true;
        }
    }
}

