﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InmobiliariaGoni.Models
{
    public class House
    {
        public int Id { get; set; }
        public string HouseTitle { get; set; }
        public string HouseCode { get; set; }
        public string Description { get; set; }
        public DateTime AvailableFrom { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
        [NotMapped]
        public ICollection<string> TagList { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}