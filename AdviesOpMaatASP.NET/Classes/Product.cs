using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Product
    {
        public int id { get; set; }
        string naam;
        double prijs;
        public List<Categorie> Categorieen { get; set; }

        public Product(int id, string naam, double prijs) 
        {
            this.id = id;
            this.naam = naam;
            this.prijs = prijs;
        }

        public Product(string naam, double prijs) // om product toe te voegen (ID is dan nog onbekend)
        {
            this.naam = naam;
            this.prijs = prijs;
        }

        public Product(string naam, double prijs, List<Categorie> categorieen) // not sure of deze gebruikt gaat worden
        {
            this.naam = naam;
            this.prijs = prijs;
            this.Categorieen = categorieen;
        }

        public double Prijs { get { return prijs; } }

        public string Naam { get { return naam; } }

        public override string ToString()
        {
            return naam;
        }
    }
}
