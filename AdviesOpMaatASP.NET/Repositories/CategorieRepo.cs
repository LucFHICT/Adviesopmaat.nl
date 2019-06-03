using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Interfaces;

namespace AdviesOpMaatASP.NET.Repositories
{
    public class CategorieRepo
    {
        readonly ICategorie _context;
        public CategorieRepo(ICategorie context)
        {
            _context = context;
        }

        public void AddCategorie(Categorie categorie)
        {
            _context.AddCategorie(categorie);
        }
        public void DeleteCategorie(Categorie categorie)
        {
            _context.DeleteCategorie(categorie);
        }
        public void UpdateCategorie(Categorie categorie)
        {
            _context.UpdateCategorie(categorie);
        }

        public List<Categorie> CategorieenBijProduct(int productId)
        {
           return _context.CategorieenBijProduct(productId);
        }
        public List<Categorie> AlleCategorieen()
        {
            return _context.AlleCategorieen();
        }
        public List<Categorie> GetCategoriesById(List<int> CategorieIds)
        {
            return _context.GetCategoriesById(CategorieIds);
        }
    }
}
