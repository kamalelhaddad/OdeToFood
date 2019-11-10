using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data {
    public class InMemoryRestaurantData : IRestaurantData {

        public List<Restaurant> Resturants;  
        public InMemoryRestaurantData() {
            Resturants = new List<Restaurant> {
                new Restaurant {Id= 1,Name = "Atyab Shamy",Cuisine = CuisineType.Syrian, Location = "6 October"},
                new Restaurant {Id= 2,Name = "Bastawesy",Cuisine = CuisineType.Italian, Location = "Dokki"},
                new Restaurant {Id= 3,Name = "China Twon",Cuisine = CuisineType.Chinies, Location = "Zayed"},
                new Restaurant {Id= 4,Name = "Maharaja",Cuisine = CuisineType.Indian,Location = "Tanta"}
            };
        }

        public Restaurant GetById(int id) {
            return Resturants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant) {
            var resturant = Resturants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (resturant != null) {
                resturant.Name = updatedRestaurant.Name;
                resturant.Location = updatedRestaurant.Location;
                resturant.Cuisine = updatedRestaurant.Cuisine;
            }

            return resturant;
        }

        public Restaurant Add(Restaurant newRestaurant) {
            newRestaurant.Id = Resturants.Max(r => r.Id) + 1;
            Resturants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id) {
            var restaurant = Resturants.SingleOrDefault(r => r.Id == id);
            if(restaurant != null)
                Resturants.Remove(restaurant);
            return restaurant;
        }

        public int Commit() {
            return 0;
        }

        public IEnumerable<Restaurant> GetResturantsByName(string name = null) {
            return Resturants.Where(r=> string.IsNullOrEmpty(name) || r.Name.Contains(name)).OrderBy(r => r.Name);
            //return from r in resturants
            //       where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            //       orderby r.Name
            //       select r;
        }
    }
}
