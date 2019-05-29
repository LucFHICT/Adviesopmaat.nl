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

        public IActionResult Beheer()
        {
            BeheerViewModel model = new BeheerViewModel();
            vulViewModel(model);

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Policy = "MustBeAdmin")]
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

        public IActionResult DeleteProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteProduct(BeheerViewModel model)
        {
            Product product = new Product(model.geselecteerdeProduct.id, model.geselecteerdeProduct.Naam, model.geselecteerdeProduct.Prijs);

            try
            {
                productRepo.DeleteProduct(product);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            TempData["Message"] = "<script>alert('Product succesvol verwijderd!');</script>";
            return RedirectToAction(""); // nog in te vullen
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProduct(BeheerViewModel model)
        {
            Product product = new Product(model.geselecteerdeProduct.id, model.geselecteerdeProduct.Naam, model.geselecteerdeProduct.Prijs);

            try
            {
                productRepo.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            TempData["Message"] = "<script>alert('Product succesvol geüpdatet!');</script>";
            return RedirectToAction(""); // nog in te vullen
        }

        [HttpPost]
        public IActionResult openPartial([FromBody] Message message, BeheerViewModel model)
        {
            vulViewModel(model);
            string pad = "Beheer/_Beheer" + message.Naam;
            return PartialView(pad, model);
        }

        public class Message
        {
            public string Naam { get; set; }
        }

        private BeheerViewModel vulViewModel(BeheerViewModel model)
        {
            model.Producten = productRepo.AlleProducten();

            foreach (Product p in model.Producten)
            {
                p.Categorieen = categorieRepo.CategorieenBijProduct(p.id);
            }

            model.Categorieen = categorieRepo.AlleCategorieen();

            return model;
        }

    }
}