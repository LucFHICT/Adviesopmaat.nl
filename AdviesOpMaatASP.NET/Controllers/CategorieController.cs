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
    public class CategorieController : Controller
    {
        CategorieRepo repo = new CategorieRepo(new CategorieContext());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCategorie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategorie(AddCategorieViewModel model)
        {
            Categorie categorie = new Categorie(model.Naam, model.Soort);

            try
            {
                repo.AddCategorie(categorie);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            TempData["Message"] = "<script>alert('Categorie succesvol toegevoegd!');</script>";
            return RedirectToAction("Index", "Home");

        }
        public IActionResult DeleteCategorie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCategorie(BeheerViewModel model)
        {
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

            TempData["Message"] = "<script>alert('Categorie succesvol verwijderd!');</script>";
            return RedirectToAction(""); // nog in te vullen
        }

        public IActionResult UpdateCategorie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCategorie(BeheerViewModel model)
        {
            Categorie categorie = new Categorie(model.geselecteerdeCategorie.categorieId, model.geselecteerdeCategorie.Naam, model.geselecteerdeCategorie.Soort);

            try
            {
                repo.UpdateCategorie(categorie);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            TempData["Message"] = "<script>alert('Categorie succesvol geüpdatet!');</script>";
            return RedirectToAction(""); // nog in te vullen
        }
    }
}