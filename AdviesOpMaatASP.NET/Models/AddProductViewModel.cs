using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AdviesOpMaatASP.NET.Classes;

namespace AdviesOpMaatASP.NET.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Een product heeft een naam nodig")]
        [Display(Name = "Naam product")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Een product heeft een prijs nodig")]
        [Display(Name = "Prijs product")]
        public double Prijs { get; set; }

        [Required(ErrorMessage = "Selecteer ten minste één categorie")]
        [Display(Name = "Categorieën bij product")]
        public List<Categorie> Categorieen { get; set; }
    }
}
