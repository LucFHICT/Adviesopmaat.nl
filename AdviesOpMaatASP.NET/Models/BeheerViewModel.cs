using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;

namespace AdviesOpMaatASP.NET.Models
{
    public class BeheerViewModel
    {
        public List<Categorie> Categorieen { get; set; }
        public List<Product> Producten { get; set; }
        public Categorie geselecteerdeCategorie { get; set; }
        public Product geselecteerdeProduct { get; set; }
        public int geselecteerdProductId { get; set; }
        public BeheerViewModel()
        {
        }
    }
}
