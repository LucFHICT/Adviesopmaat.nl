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
    public class ProductController : BeheerController
    {
        ProductRepo productRepo = new ProductRepo(new ProductContext());
        CategorieRepo categorieRepo = new CategorieRepo(new CategorieContext());

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

            return RedirectToAction("Beheer", "Beheer");
        }

        [HttpPost]
        public IActionResult DeleteProduct()
        {
            BeheerViewModel model = GetViewModel();
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
            return RedirectToAction("Beheer", "Beheer"); // nog in te vullen
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

            return RedirectToAction("Beheer", "Beheer");
        }

        [HttpPost]
        public IActionResult LoadProduct([FromBody] Message message)
        {
            BeheerViewModel model = GetViewModel();
            model.geselecteerdeProduct = model.Producten.Find(p => p.id == message.ProductId);
            model.geselecteerdProductId = message.ProductId;
            setViewModel(model);

            string pad = "_Product" + message.Actie;

            return PartialView(pad, model);
        }
    }
}