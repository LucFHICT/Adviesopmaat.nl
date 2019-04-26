using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using System.Data;

namespace AdviesOpMaatASP.NET.Contexten.Readers
{
    public class CategorieReader
    {
        public Categorie createCategorieFromReader(IDataReader reader)
        {
            Categorie categorie = new Categorie(reader["CategorieNaam"].ToString(), reader["Soort"].ToString());
            return categorie;
        }
    }
}
