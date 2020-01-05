﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Models
{
    [Owned]
    public class GuitarSpecification
    {
        public int Id { get; set; }

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

        //public int GuitarId { get; set; }
        public Guitar Guitar { get; set; }
    }

    public enum Builder
    {
        Fender = 0, Martin, Taylor, Yamaha, Ibanez, Gibson, Epiphone
    }

    public enum Type
    {
        electric = 0, acoustic
    }

    public enum Model
    {
        [Description("Stratocaster")]
        Stratocaster = 0,
        [Display(Name = "Martin D-28")]
        [Description("Martin D-28")]
        MartinD28,
        [Display(Name = "Taylor Builder's Edition V-Class K14CE")]
        [Description("Taylor Builder's Edition V-Class K14CE")]
        TaylorBuildersEditionVClassK14CE,
        [Display(Name = "Yamaha A5R ARE")]
        [Description("Yamaha A5R ARE")]
        YamahaA5RARE,
        [Display(Name = "Guild Tradition D-55")]
        [Description("Guild Tradition D-55")]
        GuildTraditionD55,
        [Display(Name = "Fender CD-60S All-Mahogany")]
        [Description("Fender CD-60S All-Mahogany")]
        FenderCD60SAllMahogany,
        [Display(Name = "Ibanez Genesis Collection RG550")]
        [Description("Ibanez Genesis Collection RG550")]
        IbanezGenesisCollectionRG550,
        [Display(Name = "Gibson Les Paul Studio")]
        [Description("Gibson Les Paul Studio")]
        GibsonLesPaulStudio,
        [Display(Name = "Epiphone Les Paul Standard")]
        [Description("Epiphone Les Paul Standard")]
        EpiphoneLesPaulStandard
    }

    public enum BackWood
    {
        [Description("Alder")]
        Alder = 0,
        [Display(Name = "East Indian Rosewood")]
        [Description("East Indian Rosewood")]
        EastIndianRosewood,
        [Description("Koa")]
        Koa,
        [Display(Name = "Solid Rosewood")]
        [Description("Solid Rosewood")]
        SolidRosewood,
        [Display(Name = "Solid Indian Rosewood")]
        [Description("Solid Indian Rosewood")]
        SolidIndianRosewood,
        [Display(Name = "Laminated Mahogany")]
        [Description("Laminated Mahogany")]
        LaminatedMahogany,
        [Description("Mahogany")]
        Mahogany,
        [Display(Name = "Mahogany with maple top")]
        [Description("Mahogany with maple top")]
        MahoganyWithMapleTop,
        [Description("Basswood")]
        Basswood
    }

    public enum TopWood
    {
        [Description("Alder")]
        Alder = 0,
        [Display(Name = "Sitka Spruce")]
        [Description("Sitka Spruce")]
        SitkaSpruce,
        [Display(Name = "Torrefield Sitka spruce")]
        [Description("Torrefield Sitka spruce")]
        TorrefieldSitkaSpruce,
        [Display(Name = "Solid Sitka Spruce with A.R.E. treatment")]
        [Description("Solid Sitka Spruce with A.R.E. treatment")]
        SolidSitkaSpruceWithARETreatment,
        [Display(Name = "AAA Solid Sitka spruce")]
        [Description("AAA Solid Sitka spruce")]
        AAASolidSitkaSpruce,
        [Display(Name = "Solid Mahogany")]
        [Description("Solid Mahogany")]
        SolidMahogany,
        [Description("Mahogany")]
        Mahogany,
        [Display(Name = "Mahogany with maple top")]
        [Description("Mahogany with maple top")]
        MahoganyWithMapleTop,
        [Description("Basswood")]
        Basswood
    }

    public static class Extensions
    {
        public static string Description(this Enum _enum)
        {
            var description = string.Empty;
            var fields = _enum.GetType().GetFields();
            foreach (var field in fields)
            {
                var descriptionAttribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (descriptionAttribute != null &&
                    field.Name.Equals(_enum.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    description = descriptionAttribute.Description;
                    break;
                }
            }

            return description;
        }
    }
}
