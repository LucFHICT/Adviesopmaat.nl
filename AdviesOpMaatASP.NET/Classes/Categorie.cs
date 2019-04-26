using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Categorie
    {
        string naam;
        string soort;
        public int categorieId { get; set; }

        public Categorie(string naam, string soort) // om categorie toe te voegen (nog geen id bekend)
        {
            this.naam = naam;
            this.soort = soort;
        }

        public Categorie(int id, string naam, string soort)
        {
            this.categorieId = id;
            this.naam = naam;
            this.soort = soort;

        }

        public string Naam { get { return naam; } }
        public string Soort { get { return soort; } }

        public override string ToString()
        {
            return soort + naam;
        }
    }
}
