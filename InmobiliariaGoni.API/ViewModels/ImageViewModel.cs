using InmobiliariaGoni.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaGoni.API.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}