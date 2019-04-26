﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Interfaces;

namespace AdviesOpMaatASP.NET.Interfaces
{
    public interface ICategorie
    {
        void AddCategorie(Categorie categorie);
        List<Categorie> CategorieenBijProduct(int productID);
        List<Categorie> AlleCategorieen();
    }
}
