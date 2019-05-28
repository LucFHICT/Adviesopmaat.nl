using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;

namespace AdviesOpMaatASP.NET.Models
{
    public class AdviesViewModel
    {
        public Intake intake { get; set; }
        public List<int> geselecteerdeAO { get; set; }
        public int ao1 { get; set; }
        public int ao2 { get; set; }
        public int ao3 { get; set; }
    }
}
