using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants {
    public class EditModel : PageModel {
        private readonly IRestaurantData _RestaurantData;
        public EditModel(IRestaurantData RestaurantData) {
            _RestaurantData = RestaurantData;
        }
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int? RestaurantId) {
            Restaurant = RestaurantId.HasValue ? _RestaurantData.GetById(RestaurantId.Value) : new Restaurant();
            //return Restaurant == null ? RedirectToPage("./NotFound") : (IActionResult)Page();
            return Page();
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                Restaurant = _RestaurantData.GetById(Restaurant.Id) != null ? _RestaurantData.Update(Restaurant) : _RestaurantData.Add(Restaurant);
                return RedirectToPage("./Detail", new {RestaurantId = Restaurant.Id});
            }

            return Page();
        }
    }
}