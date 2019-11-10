using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants {
    public class DetailModel : PageModel {
        private readonly IRestaurantData _RestaurantData;

        public DetailModel(IRestaurantData RestaurantData) {
            _RestaurantData = RestaurantData;
        }
        public Restaurant Restaurant { get; set; }
        public void OnGet(int RestaurantId) {
            Restaurant = _RestaurantData.GetById(RestaurantId);
            //return Restaurant == null ? RedirectToPage("./NotFound") : (IActionResult)Page();
        }
    }
}