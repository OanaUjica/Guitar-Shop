using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace GuitarShop.Models
{
    public class Guitar
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public bool IsGuitarOfTheWeek { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public GuitarSpecifications Specifications { get; set; }
    }


}
