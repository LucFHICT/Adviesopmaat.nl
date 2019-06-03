using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Product
    {
        public int id { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public List<Categorie> Categorieen { get; set; }

        public Product()
        {
            // is nodig voor json deserialize
        }

        public Product(int id, string naam, double prijs) 
        {
            this.id = id;
            this.Naam = naam.Trim();
            this.Prijs = prijs;
        }

        public Product(string naam, double prijs) // om product toe te voegen (ID is dan nog onbekend)
        {
            this.Naam = naam;
            this.Prijs = prijs;
        }

        public Product(string naam, double prijs, List<Categorie> categorieen) // not sure of deze gebruikt gaat worden
        {
            this.Naam = naam;
            this.Prijs = prijs;
            this.Categorieen = categorieen;
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
