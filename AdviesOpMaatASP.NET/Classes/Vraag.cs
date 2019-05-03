using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Vraag
    {
        public int VraagId { get; set; }
        public string VraagTekst { get; set; }
        public bool Geavenceerd { get; set; }
        public List<Antwoordoptie> Antwoordopties { get; set; }

        public Vraag(int id, string vraagTekst, bool geavenceerd)
        {
            VraagId = id;
            VraagTekst = vraagTekst;
            Geavenceerd = geavenceerd;
        }

        public override string ToString()
        {
            return VraagTekst;
        }
    }
}
