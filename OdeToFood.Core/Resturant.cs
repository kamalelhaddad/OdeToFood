﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core {
    public class Resturant {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(500)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
