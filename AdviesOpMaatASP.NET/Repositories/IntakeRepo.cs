using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Interfaces;

namespace AdviesOpMaatASP.NET.Repositories
{
    public class IntakeRepo
    {
        readonly IIntake _context;
        public IntakeRepo(IIntake context)
        {
            _context = context;
        }
        public List<Vraag> AlleVragen()
        {
            return _context.AlleVragen();
        }
        public List<Antwoordoptie> getAntwoord(List<int> AntwoordoptieIDs)
        {
            return _context.getAntwoord(AntwoordoptieIDs);
        }
    }
}
