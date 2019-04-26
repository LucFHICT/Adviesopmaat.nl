using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using AdviesOpMaatASP.NET.Classes;

namespace AdviesOpMaatASP.NET.Readers
{
    public class GebruikerReader
    {
        public Gebruiker createGebruikerFromReader (IDataReader reader)
        {
            Gebruiker gebruiker = new Gebruiker(reader["Gebruikersnaam"].ToString(), Convert.ToInt32(reader["RolInt"]));

            return gebruiker;
        }
    }
}
