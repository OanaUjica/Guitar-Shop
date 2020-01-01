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
        [EnumDataType(typeof(Builder), ErrorMessage = "Please enter a builder.")]
        public Builder Builder { get; set; }

        [Required]
        [EnumDataType(typeof(Model), ErrorMessage = "Please enter a model.")]
        public Model Model { get; set; }

        [Required]
        [EnumDataType(typeof(Type), ErrorMessage = "Please enter a type.")]
        public Type Type { get; set; }

        [Required]
        [EnumDataType(typeof(BackWood), ErrorMessage = "Please enter a back wood type.")]
        [Display(Name = "Back Wood")]
        public BackWood BackWood { get; set; }

        [Required]
        [EnumDataType(typeof(TopWood), ErrorMessage = "Please enter a top wood type.")]
        [Display(Name = "Top Wood")]
        public TopWood TopWood { get; set; }

        public bool IsGuitarOfTheWeek { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }

    public enum Builder
    {
        Fender, Martin, Taylor, Yamaha, Ibanez, Gibson, Epiphone
    }

    public enum Type
    {
        electric, acoustic
    }

    public enum Model
    {
        Stratocastor, Martin, TaylorBuilderEdition, Yamaha, GuildTradition, FenderAllMahogany, Ibanez, Gibson, Epiphone
    }

    public enum BackWood
    {
        Alder, EastIndianRosewood, Koa, SolidRosewood, SolidIndianRosewood, LaminatedMahogany, Mahogany, Basswood
    }

    public enum TopWood
    {
        Alder, SitkaSpruce, TorrefieldSitkaSpruce, SolidSitkaSpruce, SolidMahogany, Basswood, Mahogany
    }
}
