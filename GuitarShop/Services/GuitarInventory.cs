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
            var allGuitars = GetGuitarsFromDatabase();
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
        public List<Guitar> Search(GuitarSpecification searchGuitar)
        {
            var matchingGuitars = new List<Guitar>();
            var allGuitars = GetGuitarsFromDatabase();

            foreach (var guitar in allGuitars)
            {
                if(guitar != null)
                {
                    if (guitar.Specifications.Matches(searchGuitar)) matchingGuitars.Add(guitar);
                }                    
                else return NullReferenceException();
            }
            return matchingGuitars;
        }


        // Method invoked to get all the guitars from database
        private List<Guitar> GetGuitarsFromDatabase()
        {
            var specs = _appDbContext.GuitarSpecifications.ToList();
            var allGuitars = _appDbContext.Guitars.ToList();
            return allGuitars;
        }

        // Method invoked only if there is no guitar in the database
        private List<Guitar> NullReferenceException()
        {
            throw new NotImplementedException("There are no specifications!");
        }


    }
}
