using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class GeschiktProduct
    {
        public Product Product { get; set; }
        public int aantalOvereenkomsten { get; set; }

        public GeschiktProduct(Product product, int aantalOvereenkomsten)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            this.aantalOvereenkomsten = aantalOvereenkomsten;
        }

        public override string ToString()
        {
            return Product.Naam + " met " + aantalOvereenkomsten.ToString() + "overeenkomsten";
        }
    }
}
