using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Interfaces;

namespace AdviesOpMaatASP.NET.Repositories
{
    public class GebruikerRepo
    {
        readonly IGebruiker _context;

        public GebruikerRepo(IGebruiker context)
        {
            _context = context;
        }

        public Gebruiker CreateGebruiker (string gebruikersnaam, string wachtwoord)
        {
            return _context.CreateGebruiker(gebruikersnaam, wachtwoord);
        }

        public Gebruiker Login (string gebruikersnaam, string wachtwoord)
        {
            return _context.Login(gebruikersnaam, wachtwoord);
        }
    }
}
