﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class WishListItem
    {
        public int Id { get; set; }

        public Guitar Guitar { get; set; }
    }
}
