using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Gebruiker
    {
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Rol { get; set; }

        public Gebruiker()
        {

        }

        public Gebruiker(string gebruikersnaam, string wachtwoord)
        {
            this.Gebruikersnaam = gebruikersnaam;
            this.Wachtwoord = wachtwoord;
        }

        public Gebruiker(string gebruikersnaam, int rol)
        {
            Gebruikersnaam = gebruikersnaam;
            switch (rol)
            {
                case 1:
                    Rol = "Admin";
                    break;
                case 2:
                    Rol = "Medewerker";
                    break;
                default:
                    Rol = "NotSet";
                    break;
            }
                
        }
    }
}
