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
    public class BeheerController : Controller
    {
        

        public IActionResult Beheer()
        {
            BeheerViewModel model = new BeheerViewModel();

            if(GetViewModel()==null)
            {
                vulViewModel(model);
                setViewModel(model);
            }
            else
            {
                model = GetViewModel();
            }

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult openPartial([FromBody] Message message)
        {
            BeheerViewModel model = GetViewModel();
            string pad = "_Beheer" + message.Naam;
            return PartialView(pad, model);
        }

        public class Message
        {
            public string Naam { get; set; }
            public int ProductId { get; set; }
            public int CategorieId { get; set; }
            public string Actie { get; set; }
        }

        private BeheerViewModel vulViewModel(BeheerViewModel model)
        {
            ProductRepo productRepo = new ProductRepo(new ProductContext());
            CategorieRepo categorieRepo = new CategorieRepo(new CategorieContext());

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

        public void setViewModel(BeheerViewModel model)
        {
            HttpContext.Session.SetObject("beheerVM", model);
        }

        public BeheerViewModel GetViewModel()
        {
            BeheerViewModel model = HttpContext.Session.GetObject<BeheerViewModel>("beheerVM");
            return model;
        }
    }
}