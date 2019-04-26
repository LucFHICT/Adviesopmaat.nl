using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;

namespace AdviesOpMaatASP.NET.Interfaces
{
    public interface IGebruiker
    {
        Gebruiker CreateGebruiker(string gebruikersnaam, string wachtwoord);
        Gebruiker Login(string gebruikersnaam, string wachtwoord);
    }
}
