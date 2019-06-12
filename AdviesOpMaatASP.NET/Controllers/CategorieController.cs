using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdviesOpMaatASP.NET.Controllers;
using AdviesOpMaatASP.NET.Models;
using AdviesOpMaatASP.NET.Contexten;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Repositories;

namespace AdviesOpMaatASP.NET.Controllers
{
    public class CategorieController : BeheerController
    {
        CategorieRepo repo = new CategorieRepo(new CategorieContext());

        public IActionResult AddCategorie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategorie(BeheerViewModel model)
        {
            Categorie categorie = new Categorie(model.editCategorieNaam, model.editCategorieSoort);

            try
            {
                repo.AddCategorie(categorie);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            return RedirectToAction("Beheer", "Beheer");
        }

        [HttpPost]
        public IActionResult DeleteCategorie()
        {
            BeheerViewModel model = GetViewModel();
            Categorie categorie = new Categorie(model.geselecteerdeCategorie.categorieId, model.geselecteerdeCategorie.Naam, model.geselecteerdeCategorie.Soort);

            try
            {
                repo.DeleteCategorie(categorie);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            return RedirectToAction("Beheer", "Beheer");
        }

        public IActionResult UpdateCategorie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCategorie(BeheerViewModel model)
        {
            Categorie categorie = new Categorie(model.geselecteerdeCategorie.categorieId, model.geselecteerdeCategorie.Naam, model.geselecteerdeCategorie.Soort);
            model = GetViewModel();
            categorie.categorieId = model.geselecteerdCategorieId;

            try
            {
                repo.UpdateCategorie(categorie);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            return RedirectToAction("Beheer", "Beheer"); 
        }

        [HttpPost]
        public IActionResult LoadCategorie([FromBody] Message message)
        {
            BeheerViewModel model = GetViewModel();
            model.geselecteerdeCategorie = model.Categorieen.Find(c => c.categorieId == message.CategorieId);
            model.geselecteerdCategorieId = message.CategorieId;
            setViewModel(model);

            string pad = "_Categorie" + message.Actie;

            return PartialView(pad, model);
        }

    }
}