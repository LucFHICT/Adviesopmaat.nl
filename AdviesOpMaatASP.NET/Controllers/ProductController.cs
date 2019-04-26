using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdviesOpMaatASP.NET.Controllers;
using AdviesOpMaatASP.NET.Models;
using AdviesOpMaatASP.NET.Contexten;
using AdviesOpMaatASP.NET.Classes;
    using Microsoft.AspNetCore.Authorization;
using AdviesOpMaatASP.NET.Repositories;

namespace AdviesOpMaatASP.NET.Controllers
{
    public class ProductController : Controller
    {
        ProductRepo productRepo = new ProductRepo(new ProductContext());
        CategorieRepo categorieRepo = new CategorieRepo(new CategorieContext());

        public IActionResult Index()
        {
            OverzichtViewModel overzichtViewModel = new OverzichtViewModel();
            vulProducten(overzichtViewModel);
            vulCategorieen(overzichtViewModel);

            return View(overzichtViewModel);
        }
        [Authorize(Policy = "MustBeAdmin")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            Product product = new Product(model.Naam, model.Prijs);

            try
            {
                productRepo.AddProduct(product);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            TempData["Message"] = "<script>alert('Product succesvol toegevoegd!');</script>";
            return RedirectToAction("Index", "Home");
        }

        private void vulProducten(OverzichtViewModel model)
        {
            model.Producten = productRepo.AlleProducten();

            foreach (Product p in model.Producten)
            {
                p.Categorieen = categorieRepo.CategorieenBijProduct(p.id);
            }
        }
        private void vulCategorieen(OverzichtViewModel model) 
        {
            model.Categorieen = categorieRepo.AlleCategorieen();

            //ArtikelEnCategorieViewmodel ACViewmodel = aCViewmodel;                     << Indien viewmodel in een viewmodel zit(partials)
                                                                                       
            //ArtikelViewModel artikelViewModel = new ArtikelViewModel();                << Instantieer nieuwe viewmodels om te vullen 
            //CategorieViewmodel categorieViewmodel = new CategorieViewmodel();

            //artikelViewModel.artikelen = aCViewmodel.ArtikelViewModel.artikelen;       << Haalt artikelen uit een ander viewmodel, not sure waarom
            //ACViewmodel.ArtikelViewModel = artikelViewModel;                           << Stel gelijk aan main-viewmodel

            //categorieViewmodel.categorieen = artikelRepo.GetAllCategorie();            << Spreek repo aan voor data
            //ACViewmodel.CategorieViewmodel = categorieViewmodel;
        }

    }
}