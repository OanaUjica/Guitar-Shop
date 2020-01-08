using GuitarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Services
{
    public interface IGuitarInventory
    {
        List<Guitar> GetAllGuitars();

        Guitar GetGuitarById(int guitarId);

        List<Guitar> Search(GuitarSpecification searchGuitar);
    }
}
