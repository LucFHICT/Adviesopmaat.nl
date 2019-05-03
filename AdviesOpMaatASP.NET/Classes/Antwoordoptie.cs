using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Antwoordoptie
    {
        public string Antwoord { get; set; }
        public Categorie Categorie { get; set; }

        public Antwoordoptie(string antwoord, Categorie categorie)
        {
            Antwoord = antwoord;
            Categorie = categorie;
        }
        public override string ToString()
        {
            return Antwoord;
        }
    }
}
