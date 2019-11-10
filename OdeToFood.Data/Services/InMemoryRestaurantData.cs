using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data {
    public class InMemoryRestaurantData : IRestaurantData {

        public List<Restaurant> Restaurants;  
        public InMemoryRestaurantData() {
            Restaurants = new List<Restaurant> {
                new Restaurant {Id= 1,Name = "Atyab Shamy",Cuisine = CuisineType.Syrian, Location = "6 October"},
                new Restaurant {Id= 2,Name = "Bastawesy",Cuisine = CuisineType.Italian, Location = "Dokki"},
                new Restaurant {Id= 3,Name = "China Twon",Cuisine = CuisineType.Chinies, Location = "Zayed"},
                new Restaurant {Id= 4,Name = "Maharaja",Cuisine = CuisineType.Indian,Location = "Tanta"}
            };
        }

        public Restaurant GetById(int id) {
            return Restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant) {
            var Restaurant = Restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (Restaurant != null) {
                Restaurant.Name = updatedRestaurant.Name;
                Restaurant.Location = updatedRestaurant.Location;
                Restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return Restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant) {
            newRestaurant.Id = Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id) {
            var restaurant = Restaurants.SingleOrDefault(r => r.Id == id);
            if(restaurant != null)
                Restaurants.Remove(restaurant);
            return restaurant;
        }

        public int Commit() {
            return 0;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) {
            return Restaurants.Where(r=> string.IsNullOrEmpty(name) || r.Name.Contains(name)).OrderBy(r => r.Name);
            //return from r in Restaurants
            //       where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            //       orderby r.Name
            //       select r;
        }
    }
}
