using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Interfaces;

namespace AdviesOpMaatASP.NET.Interfaces
{
    public interface IIntake
    {
        List<Antwoordoptie> getAntwoord(List<int> AntwoordoptieIDs);
        List<Vraag> AlleVragen();

    }
}
