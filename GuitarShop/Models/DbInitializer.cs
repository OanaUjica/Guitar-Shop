using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Guitars.Any())
            {
                context.AddRange
                (
                    new Guitar {Price = 1499.95M, Builder = "Fender", Model = "Stratocastor", Type = "electric", BackWood = "Alder", TopWood = "Alder", IsGuitarOfTheWeek = true },
                    new Guitar {Price = 2779.95M, Builder = "Fender", Model = "Stratocastor", Type = "electric", BackWood = "Alder", TopWood = "Alder", IsGuitarOfTheWeek = false }
                );
            }
            context.SaveChanges();
        }
    }
}
