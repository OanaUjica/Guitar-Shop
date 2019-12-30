using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    public class Guitar
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        [Required]
        [EnumDataType(typeof(Builder))]
        public Builder Builder { get; set; }

        [Required]
        [EnumDataType(typeof(Model))]
        public Model Model { get; set; }

        [Required]
        [EnumDataType(typeof(Type))]
        public Type Type { get; set; }

        [Required]
        [EnumDataType(typeof(BackWood))]
        public BackWood BackWood { get; set; }

        [Required]
        [EnumDataType(typeof(TopWood))]
        public TopWood TopWood { get; set; }

        public bool IsGuitarOfTheWeek { get; set; }

    }

    public enum Builder
    {
        Fender, Martin, Taylor, Yamaha
    }

    public enum Type
    {
        electric, acoustic
    }

    public enum Model
    {
        Stratocastor, Martin, TaylorBuilderEdition, Yamaha, GuildTradition, FenderAllMahogany 
    }

    public enum BackWood
    {
        Alder, EastIndianRosewood, Koa, SolidRosewood, SolidIndianRosewood, LaminatedMahogany
    }

    public enum TopWood
    {
        Alder, SitkaSpruce, TorrefieldSitkaSpruce, SolidSitkaSpruce, SolidMahogany
    }
}
