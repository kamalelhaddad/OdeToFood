using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants {
    public class DetailModel : PageModel {
        private readonly IResturantData _resturantData;

        public DetailModel(IResturantData resturantData) {
            _resturantData = resturantData;
        }
        public Resturant Resturant { get; set; }
        public void OnGet(int resturantId) {
            Resturant = _resturantData.GetById(resturantId);
            //return Resturant == null ? RedirectToPage("./NotFound") : (IActionResult)Page();
        }
    }
}