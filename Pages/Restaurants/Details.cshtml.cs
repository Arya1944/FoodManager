using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodManager.Core;
using FoodManager.Data;


namespace FoodManager.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        public Core.Restaurant Restaurant {get;set;}

        private readonly IRestaurantData restaurantData;
        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;

        }

       
        public void OnGet(Guid restaurantId)
        {
            Restaurant= restaurantData.GetByID(restaurantId);
        }

        private void calculateEven()
        {
           int[] mylist =  {1,3,5,10,16 };
            int sum = 0;
            foreach (var n in mylist)
            {
                if (n / 2 == 0)
                {
                    sum += n;
                }
            }

            var result = sum;

            result = mylist.Where(i => i % 2 == 0).Sum();

        }
    }
}