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
        public List<string> Soorten { get; set; }
        public Categorie geselecteerdeCategorie { get; set; }
        public Product geselecteerdeProduct { get; set; }
        public int geselecteerdProductId { get; set; }
        public string editProductNaam { get; set; }
        public int editProductPrijs { get; set; }
        public IEnumerable<int> categorieenIdBijProduct { get; set; }
        public string editCategorieNaam { get; set; }
        public string editCategorieSoort { get; set; }
        public int geselecteerdCategorieId { get; set; }
        public BeheerViewModel()
        {
        }
    }
}
