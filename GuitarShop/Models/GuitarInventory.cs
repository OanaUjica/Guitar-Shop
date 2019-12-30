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


        // review this method!!!
        public List<Guitar> GetAllGuitars()
        {
            throw new NotImplementedException();
        }


        //// Get all guitars from database
        //public List<Guitar> GetAllGuitars()
        //{
        //    return _appDbContext.Guitars;
        //}

        // Get guitar by Id from the database
        public Guitar GetGuitarById(int guitarId)
        {
            return _appDbContext.Guitars.FirstOrDefault(g => g.Id == guitarId);
        }

        // Search for the list of guitar, from the database, that matches the user requirements
        public List<Guitar> Search(Guitar searchGuitar)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();
            var guitar = _appDbContext.Guitars.FirstOrDefault(g => g.Builder == searchGuitar.Builder);
            matchingGuitars.Add(guitar);
            return matchingGuitars;
        }
    }
}
