using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using FoodManager.Core;


namespace FoodManager.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private IConfiguration config;
        public string Message { get; set; }
        public IEnumerable<Restaurant> restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchName { get; set; }

        private IRestaurantData restaurantData;

       public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
            this.config = config;
        }
        public void OnGet()
        {
            
            Message = config["Message"];
            restaurants = Search();
            
        }

        public IEnumerable<Restaurant> Search()
        {
            if (!string.IsNullOrEmpty(SearchName))
            {
                return restaurantData.GetByName(SearchName);
            }
            return restaurantData.GetAll(); 
        }
    }
}