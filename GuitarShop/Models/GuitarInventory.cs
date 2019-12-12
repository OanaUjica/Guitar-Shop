using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class GuitarInventory : IGuitarInventory
    {
        private readonly AppDbContext _appDbContext;

        public GuitarInventory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public IEnumerable<Guitar> GetAllGuitars()
        {
            return _appDbContext.Guitars;
        }

        public Guitar GetGuitarById(int guitarId)
        {
            return _appDbContext.Guitars.FirstOrDefault(g => g.Id == guitarId);
        }

        public List<Guitar> Search(Guitar searchGuitar)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();
            var guitar = _appDbContext.Guitars.FirstOrDefault(g => g.Builder == searchGuitar.Builder);
            matchingGuitars.Add(guitar);
            return matchingGuitars;
        }
    }
}
