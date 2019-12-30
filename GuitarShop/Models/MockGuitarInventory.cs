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
            _guitars = new List<Guitar> {
                new Guitar { Id = 1, Price = 1499.95M, Builder = Builder.Fender, Model = Model.Stratocastor, Type = Type.electric, BackWood = BackWood.Alder, TopWood = TopWood.Alder, IsGuitarOfTheWeek = true },
                new Guitar { Id = 2, Price = 2779.95M, Builder = Builder.Fender, Model = Model.Stratocastor, Type = Type.electric, BackWood = BackWood.Alder, TopWood = TopWood.Alder, IsGuitarOfTheWeek = false },
                new Guitar { Id = 3, Price = 3399.95M, Builder = Builder.Martin, Model = Model.Martin, Type = Type.acoustic, BackWood = BackWood.EastIndianRosewood, TopWood = TopWood.SitkaSpruce, IsGuitarOfTheWeek = false },
                new Guitar { Id = 4, Price = 4999.95M, Builder = Builder.Taylor, Model = Model.TaylorBuilderEdition, Type = Type.acoustic, BackWood = BackWood.Koa, TopWood = TopWood.TorrefieldSitkaSpruce, IsGuitarOfTheWeek = false },
                new Guitar { Id = 5, Price = 1400M, Builder = Builder.Yamaha, Model = Model.Yamaha, Type = Type.acoustic, BackWood = BackWood.SolidRosewood, TopWood = TopWood.SolidSitkaSpruce, IsGuitarOfTheWeek = false },
                new Guitar { Id = 6, Price = 3800M, Builder = Builder.Fender, Model = Model.GuildTradition, Type = Type.acoustic, BackWood = BackWood.SolidIndianRosewood, TopWood = TopWood.SolidSitkaSpruce, IsGuitarOfTheWeek = false },
                new Guitar { Id = 7, Price = 199.90M, Builder = Builder.Fender, Model = Model.FenderAllMahogany, Type = Type.acoustic, BackWood = BackWood.LaminatedMahogany, TopWood = TopWood.SolidMahogany, IsGuitarOfTheWeek = false }

            };
        }


        public List<Guitar> GetAllGuitars()
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

            foreach (var guitar in _guitars)
            {
                if (guitar.Builder != searchGuitar.Builder) continue;
                if (guitar.Model != searchGuitar.Model) continue;
                if (guitar.Type != searchGuitar.Type) continue;
                if (guitar.BackWood != searchGuitar.BackWood) continue;
                if (guitar.TopWood != searchGuitar.TopWood) continue;
                matchingGuitars.Add(guitar);
            }

            return matchingGuitars;
        }
    }
}
