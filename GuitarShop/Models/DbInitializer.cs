using System.Linq;


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
                        new Guitar { Price = 1499.95M, Builder = Builder.Fender, Model = Model.Stratocastor, Type = Type.electric, BackWood = BackWood.Alder, TopWood = TopWood.Alder, IsGuitarOfTheWeek = true },
                        new Guitar { Price = 2779.95M, Builder = Builder.Fender, Model = Model.Stratocastor, Type = Type.electric, BackWood = BackWood.Alder, TopWood = TopWood.Alder, IsGuitarOfTheWeek = false },
                        new Guitar { Price = 3399.95M, Builder = Builder.Martin, Model = Model.Martin, Type = Type.acoustic, BackWood = BackWood.EastIndianRosewood, TopWood = TopWood.SitkaSpruce, IsGuitarOfTheWeek = false },
                        new Guitar { Price = 4999.95M, Builder = Builder.Taylor, Model = Model.TaylorBuilderEdition, Type = Type.acoustic, BackWood = BackWood.Koa, TopWood = TopWood.TorrefieldSitkaSpruce, IsGuitarOfTheWeek = false },
                        new Guitar { Price = 1400M, Builder = Builder.Yamaha, Model = Model.Yamaha, Type = Type.acoustic, BackWood = BackWood.SolidRosewood, TopWood = TopWood.SolidSitkaSpruce, IsGuitarOfTheWeek = false },
                        new Guitar { Price = 3800M, Builder = Builder.Fender, Model = Model.GuildTradition, Type = Type.acoustic, BackWood = BackWood.SolidIndianRosewood, TopWood = TopWood.SolidSitkaSpruce, IsGuitarOfTheWeek = false },
                        new Guitar { Price = 199.90M, Builder = Builder.Fender, Model = Model.FenderAllMahogany, Type = Type.acoustic, BackWood = BackWood.LaminatedMahogany, TopWood = TopWood.SolidMahogany, IsGuitarOfTheWeek = false }
                );
            }
            context.SaveChanges();
        }
    }
}
