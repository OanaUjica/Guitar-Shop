using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public Guitar Guitar { get; set; }
    }
}
