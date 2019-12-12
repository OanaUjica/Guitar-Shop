using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public interface IGuitarInventory
    {
        IEnumerable<Guitar> GetAllGuitars();

        Guitar GetGuitarById(int guitarId);

        List<Guitar> Search(Guitar searchGuitar);
    }
}
