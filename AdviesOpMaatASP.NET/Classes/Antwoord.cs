using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Antwoord
    {
        public List<Antwoordoptie> Antwoordopties { get; set; }

        public Antwoord(List<Antwoordoptie> antwoordopties)
        {
            Antwoordopties = antwoordopties;
        }
    }
}
