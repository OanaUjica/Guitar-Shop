using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class Guitar
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Builder { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string BackWood { get; set; }
        public string TopWood { get; set; }
        public bool IsGuitarOfTheWeek { get; set; }

    }
}
