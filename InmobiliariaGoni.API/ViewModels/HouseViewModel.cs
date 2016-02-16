using InmobiliariaGoni.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaGoni.API.ViewModels
{
    public class HouseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string HouseTitle { get; set; }
        [Required]
        public string HouseCode { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Description { get; set; }
        public DateTime AvailableFrom { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public IEnumerable<string> TagList { get; set; }
        public IEnumerable<ImageViewModel> Images { get; set; }
    }
}
