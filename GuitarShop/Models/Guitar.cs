using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarShop.Models
{
    public class Guitar
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool IsGuitarOfTheWeek { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public GuitarSpecification Specifications { get; set; }

    }


}
