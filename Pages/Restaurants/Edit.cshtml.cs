using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodManager.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodManager.Data;

namespace FoodManager.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

   
        public Restaurant Restaurant { get; set; }

        public EditModel(IRestaurantData restaurantData) {

            this.restaurantData = restaurantData;
        }
        public void OnGet(Guid restaurantId)
        {
            Restaurant = restaurantData.GetByID(restaurantId);
        }


    }
}