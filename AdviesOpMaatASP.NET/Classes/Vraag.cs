using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Vraag
    {
        public string VraagTekst { get; set; }
        public bool Geavenceerd { get; set; }
        List<Antwoordoptie> Antwoordopties { get; set; }

        public Vraag(string vraagTekst, bool geavenceerd)
        {
            VraagTekst = vraagTekst;
            Geavenceerd = geavenceerd;
        }

        public override string ToString()
        {
            return VraagTekst;
        }
    }
}
