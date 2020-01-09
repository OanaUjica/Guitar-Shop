using GuitarShop.Models;
using System.Collections.Generic;


namespace GuitarShop.Services
{
    public interface IGuitarInventory
    {
        List<Guitar> GetAllGuitars();

        Guitar GetGuitarById(int guitarId);

        List<Guitar> Search(GuitarSpecification searchGuitar);
    }
}
