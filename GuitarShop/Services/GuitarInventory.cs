using GuitarShop.Database;
using GuitarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GuitarShop.Services
{
    public class GuitarInventory : IGuitarInventory
    {
        private readonly AppDbContext _appDbContext;

        public GuitarInventory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Get all guitars from database
        public List<Guitar> GetAllGuitars()
        {
            var specs = _appDbContext.GuitarSpecifications.ToList();
            var allGuitars = _appDbContext.Guitars.ToList();

            return allGuitars;
        }

        // Get guitar by Id from the database
        public Guitar GetGuitarById(int guitarId)
        {
            var specs = _appDbContext.GuitarSpecifications.ToList();
            var guitarById = _appDbContext.Guitars.FirstOrDefault(g => g.Id == guitarId); 
            return guitarById;
        }

        // Search for the list of guitar, from the database, that matches the user requirements
        public List<Guitar> Search(GuitarSpecification _searchGuitar)
        {
            var matchingGuitars = new List<Guitar>();
            var spec = _appDbContext.GuitarSpecifications.ToList();
            var allPropGuitars = _appDbContext.Guitars.ToList();

            foreach (var guitar in allPropGuitars)
            {
                if(guitar != null)
                {
                    if (guitar.Specifications.Builder != _searchGuitar.Builder) continue;
                    if (guitar.Specifications.Model != _searchGuitar.Model) continue;
                    if (guitar.Specifications.Type != _searchGuitar.Type) continue;
                    if (guitar.Specifications.BackWood != _searchGuitar.BackWood) continue;
                    if (guitar.Specifications.TopWood != _searchGuitar.TopWood) continue;
                    matchingGuitars.Add(guitar);
                }
                else return NullReferenceException();
            }

            return matchingGuitars;
        }


        // Method invoked only if there is no guitar in the database
        private List<Guitar> NullReferenceException()
        {
            throw new NotImplementedException("There are no specifications!");
        }


    }
}
