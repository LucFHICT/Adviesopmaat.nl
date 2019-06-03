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
            setViewModel(model);

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
        public IActionResult AddProduct(BeheerViewModel model)
        {
            Product product = new Product(model.editProductNaam, model.editProductPrijs);
            List<int> categorieIds = model.categorieenIdBijProduct.ToList<int>();
            product.Categorieen = categorieRepo.GetCategoriesById(categorieIds);

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

        [HttpPost]
        public IActionResult DeleteProduct()
        {
            BeheerViewModel model = HttpContext.Session.GetObject<BeheerViewModel>("beheerVM");
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
            return RedirectToAction("Beheer", "Product"); // nog in te vullen
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProduct(BeheerViewModel model)
        {
            Product product = new Product(model.editProductNaam, model.editProductPrijs);
            model = GetViewModel();
            product.id = model.geselecteerdProductId;

            try
            {
                productRepo.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                throw;
            }

            return RedirectToAction("Beheer", "Product");
        }

        [HttpPost]
        public IActionResult openPartial([FromBody] Message message)
        {
            BeheerViewModel model = HttpContext.Session.GetObject<BeheerViewModel>("beheerVM");
            string pad = "Beheer/_Beheer" + message.Naam;
            return PartialView(pad, model);
        }

        [HttpPost]
        public IActionResult LoadProduct([FromBody] Message message)
        {
            BeheerViewModel model = HttpContext.Session.GetObject<BeheerViewModel>("beheerVM");
            model.geselecteerdeProduct = model.Producten.Find(p => p.id == message.ProductId);
            model.geselecteerdProductId = message.ProductId;
            setViewModel(model);

            string pad = "Beheer/_Product" + message.Actie;

            return PartialView(pad, model);
        }
        public class Message
        {
            public string Naam { get; set; }
            public int ProductId { get; set; }
            public string Actie { get; set; }
        }

        private BeheerViewModel vulViewModel(BeheerViewModel model)
        {
            model.Producten = productRepo.AlleProducten();

            foreach (Product p in model.Producten)
            {
                p.Categorieen = categorieRepo.CategorieenBijProduct(p.id);
            }

            model.Categorieen = categorieRepo.AlleCategorieen();

            model.Soorten = new List<string>();
            foreach (Categorie c in model.Categorieen)
            {
                if(!model.Soorten.Contains(c.Soort.ToString()))
                {
                    model.Soorten.Add(c.Soort);
                }
            }
            
            return model;
        }

        private void setViewModel(BeheerViewModel model)
        {
            HttpContext.Session.SetObject("beheerVM", model);
        }

        private BeheerViewModel GetViewModel()
        {
            BeheerViewModel model = HttpContext.Session.GetObject<BeheerViewModel>("beheerVM");
            return model;
        }
    }
}