using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants {
    public class EditModel : PageModel {
        private readonly IResturantData _resturantData;
        public EditModel(IResturantData resturantData) {
            _resturantData = resturantData;
        }
        [BindProperty]
        public Resturant Resturant { get; set; }
        public IActionResult OnGet(int? resturantId) {
            Resturant = resturantId.HasValue ? _resturantData.GetById(resturantId.Value) : new Resturant();
            //return Resturant == null ? RedirectToPage("./NotFound") : (IActionResult)Page();
            return Page();
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                Resturant = _resturantData.GetById(Resturant.Id) != null ? _resturantData.Update(Resturant) : _resturantData.Add(Resturant);
                return RedirectToPage("./Detail", new {resturantId = Resturant.Id});
            }

            return Page();
        }
    }
}