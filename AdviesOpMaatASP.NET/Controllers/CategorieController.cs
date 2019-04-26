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
    }
}