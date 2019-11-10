using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages_Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData _RestaurantData;

        public string Message { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration config, IRestaurantData RestaurantData) {
            this.config = config;
            _RestaurantData = RestaurantData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = _RestaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}