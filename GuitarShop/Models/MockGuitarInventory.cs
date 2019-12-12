using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class MockGuitarInventory : IGuitarInventory
    {
        private List<Guitar> _guitars;

        public MockGuitarInventory()
        {
            if (_guitars == null)
            {
                InitializeGuitars();
            }
        }

        private void InitializeGuitars()
        {
            _guitars = new List<Guitar>
            {
                new Guitar{Id = 1, Price = 1499.95M, Builder = "Fender", Model = "Stratocastor", Type = "electric", BackWood = "Alder", TopWood = "Alder", IsGuitarOfTheWeek = true },
                new Guitar{Id = 2, Price = 2779.95M, Builder = "Fender", Model = "Stratocastor", Type = "electric", BackWood = "Alder", TopWood = "Alder", IsGuitarOfTheWeek = false }

            };
        }



        public IEnumerable<Guitar> GetAllGuitars()
        {
            return _guitars;
        }

        public Guitar GetGuitarById(int guitarId)
        {
            return _guitars.FirstOrDefault(g => g.Id == guitarId);
        }

        public List<Guitar> Search(Guitar searchGuitar)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();
            var guitar = _guitars.FirstOrDefault(g => g.Builder == searchGuitar.Builder);
            matchingGuitars.Add(guitar);
            return matchingGuitars;
        }
    }
}
