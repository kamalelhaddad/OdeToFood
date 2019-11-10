using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data {
    public class SqlRestaurantData  : IRestaurantData {
        private readonly OdeToFoodDbContext _dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext) {
            _dbContext = dbContext;
        }
        public IEnumerable<Restaurant> GetResturantsByName(string name) {
            var query = _dbContext.Restaurants.Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name)).OrderBy(r => r.Name);
            return query;
        }

        public Restaurant GetById(int id) {
            return _dbContext.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant) {
            var entity = _dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Add(Restaurant newRestaurant) {
            _dbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id) {
            var rstrnt = GetById(id);
            if (rstrnt != null)
                _dbContext.Restaurants.Remove(rstrnt);
            return rstrnt;
        }

        public int Commit() {
            return _dbContext.SaveChanges();
        }
    }
}
