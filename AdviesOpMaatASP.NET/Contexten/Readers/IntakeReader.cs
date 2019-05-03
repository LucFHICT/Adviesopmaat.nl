using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Contexten;
using AdviesOpMaatASP.NET.Contexten.Readers;

namespace AdviesOpMaatASP.NET.Contexten.Readers
{
    public class IntakeReader
    {
        CategorieReader categorieReader = new CategorieReader();

        public Vraag createVraagFromReader(IDataReader reader)
        {
            int geavenceerd = (int)reader["Kennis"];
            if (geavenceerd == 0)
            {
                Vraag vraag = new Vraag((int)reader["VraagId"], reader["Vraag"].ToString(), false);
                return vraag;
            }
            else
            {
                Vraag vraag = new Vraag((int)reader["VraagId"], reader["Vraag"].ToString(), true);
                return vraag;
            }
        }
        public Antwoordoptie createAntwoordoptieFromReader(IDataReader reader)
        {
            Antwoordoptie antwoordoptie = new Antwoordoptie(reader["Antwoord"].ToString(), categorieReader.createCategorieFromReader(reader);
            return antwoordoptie;
        }
    }
}
