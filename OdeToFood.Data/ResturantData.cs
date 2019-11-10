using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data {
    public interface IResturantData {
        IEnumerable<Resturant> GetResturantsByName(string name);
        Resturant GetById(int id);
        Resturant Update(Resturant updatedResturant);
        Resturant Add(Resturant newResturant);
    }

    public class InMemoryResturantData : IResturantData {

        public List<Resturant> Resturants;  
        public InMemoryResturantData() {
            Resturants = new List<Resturant> {
                new Resturant {Id= 1,Name = "Atyab Shamy",Cuisine = CuisineType.Syrian, Location = "6 October"},
                new Resturant {Id= 2,Name = "Bastawesy",Cuisine = CuisineType.Italian, Location = "Dokki"},
                new Resturant {Id= 3,Name = "China Twon",Cuisine = CuisineType.Chinies, Location = "Zayed"},
                new Resturant {Id= 4,Name = "Maharaja",Cuisine = CuisineType.Indian,Location = "Tanta"}
            };
        }

        public Resturant GetById(int id) {
            return Resturants.SingleOrDefault(r => r.Id == id);
        }

        public Resturant Update(Resturant updatedResturant) {
            var resturant = Resturants.SingleOrDefault(r => r.Id == updatedResturant.Id);
            if (resturant != null) {
                resturant.Name = updatedResturant.Name;
                resturant.Location = updatedResturant.Location;
                resturant.Cuisine = updatedResturant.Cuisine;
            }

            return resturant;
        }

        public Resturant Add(Resturant newResturant) {
            newResturant.Id = Resturants.Max(r => r.Id) + 1;
            Resturants.Add(newResturant);
            return newResturant;
        }

        public IEnumerable<Resturant> GetResturantsByName(string name = null) {
            return Resturants.Where(r=> string.IsNullOrEmpty(name) || r.Name.Contains(name)).OrderBy(r => r.Name);
            //return from r in resturants
            //       where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            //       orderby r.Name
            //       select r;
        }
    }
}
