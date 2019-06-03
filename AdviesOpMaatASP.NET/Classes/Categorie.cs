using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Categorie
    {
        public string Naam { get; set; }
        public string Soort { get; set; }
        public int categorieId { get; set; }

        public Categorie(string naam, string soort) // om categorie toe te voegen (nog geen id bekend)
        {
            this.Naam = naam;
            this.Soort = soort;
        }

        public Categorie(int id, string naam, string soort)
        {
            this.categorieId = id;
            this.Naam = naam.Trim();
            this.Soort = soort.Trim();

        }

        public Categorie()
        {

        }

        public override string ToString()
        {
            return Soort + Naam;
        }
    }
}
