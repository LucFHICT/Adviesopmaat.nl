using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AdviesOpMaatASP.NET.Classes;

namespace AdviesOpMaatASP.NET.Models
{
    public class OverzichtViewModel
    {
        public List<Categorie> Categorieen { get; set; }
        public List<Product> Producten { get; set; }
    }
}
