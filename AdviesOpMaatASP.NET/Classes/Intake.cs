﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdviesOpMaatASP.NET.Classes
{
    public class Intake
    {
        public Gebruiker Gebruiker { get; set; }
        public string Email { get; set; }
        public Antwoord Antwoord { get; set; }
        public List<Vraag> Vragen { get; set; }
        public bool Geavenceerd { get; set; }

public Intake()
        {

        }
    }
}
