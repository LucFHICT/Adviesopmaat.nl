using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Antwoordoptie
    {
        public int Id { get; set; }
        public string Antwoord { get; set; }
        public Categorie Categorie { get; set; }

        public Antwoordoptie(int id, string antwoord, Categorie categorie)
        {
            Id = id;
            Antwoord = antwoord;
            Categorie = categorie;
        }
        public override string ToString()
        {
            return Antwoord;
        }
    }
}
