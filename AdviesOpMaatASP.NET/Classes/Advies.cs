using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Advies
    {
        public List<GeschiktProduct> aanbevolenProducten { get; set; }
        public string email;

        public Advies(List<GeschiktProduct> gevondenProducten, string email)
        {
            this.aanbevolenProducten = gevondenProducten;
            this.email = email;
        }
    }
}
