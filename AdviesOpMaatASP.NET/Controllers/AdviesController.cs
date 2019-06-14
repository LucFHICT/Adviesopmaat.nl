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
    public class AdviesController : Controller
    {
        ProductRepo productRepo = new ProductRepo(new ProductContext());
        IntakeRepo intakeRepo = new IntakeRepo(new IntakeContext());
        public IActionResult AdviesAanvragen()
        {
            AdviesViewModel model = new AdviesViewModel();
            model.intake = new Intake();
            model.intake.Vragen = intakeRepo.AlleVragen();
            return View(model);
        }


        // vindProducten 'omdraaien'; cat op checklist laten staan ipv eraf halen om te onthouden welke overeenkomst er is???
        [HttpPost]
        public IActionResult vindProducten(AdviesViewModel model)                                        // methode wordt aangeroepen door maakAdvies()
        {
            List<GeschiktProduct> geschikteProducten = new List<GeschiktProduct>();                        // maak lijst aan voor geschikte producten

            List<Product> alleProducten = productRepo.AlleProducten();                                // haal alle producten op
            Antwoord antwoord = new Antwoord(intakeRepo.getAntwoord(model.geselecteerdeAO));            // haal gekozen antwoorden door klant op

            List<Categorie> eisCategorie = new List<Categorie>();                                          //instantieer lijst om eisen klant in te zetten

            foreach (Product p in alleProducten)
            {
                List<Categorie> categorieenBijProduct = p.Categorieen;                                  // haal bij ieder product de categorieen op
                eisCategorie.Clear();

                foreach (Antwoordoptie ao in antwoord.Antwoordopties)
                {
                    eisCategorie.Add(ao.Categorie);                                                     // vul lijst met categorieen om mee te vergelijken in obv antwoordopties
                }

                int aantalEisen = eisCategorie.Count;                                                   // onthou totaal aantal eisen vóór vergelijking om aantal overeenkomsten mee te bepalen

                foreach (Categorie ca in categorieenBijProduct)                                         // check bij iedere categorie(product) of deze voorkomt op vergelijkingslijst 
                {
                    int indexToRemove = eisCategorie.IndexOf(                                            // indien categorie gevonden (obv naam), set een int om de index te bepalen in vergelijkingslijst
                        eisCategorie.SingleOrDefault(
                            cat => cat.Naam == categorieenBijProduct.Find(
                                c => c.Naam == ca.Naam).Naam));
                   
                    if (indexToRemove != -1)                                                            // als er geen categorie is gevonden, wordt er -1 returned
                    {
                        eisCategorie.RemoveAt(indexToRemove);                                           // verwijder overeenkomende categorie obv index
                    }
                }

                if (eisCategorie.Count < aantalEisen)                                                   // filteroptie: als er tenminste 1 overeenkomende categorie is gevonden, voeg toe aan lijst geschikteproducten
                {
                    GeschiktProduct gp = new GeschiktProduct(p, aantalEisen - eisCategorie.Count);      // maak nieuw geschiktproduct en bepaal hoeveel overeenkomsten deze heeft met vergelijkingslijst
                    geschikteProducten.Add(gp);
                }
            }

            //geschikteProducten.Sort();
            model.advies = new Advies(geschikteProducten, model.intake.Email);

            return View("Adviesoverzicht", model);                                                             // op deze manier werkt eisCategorie als een checklist waar eisen (categorieen) afgevinkt worden
        }

    }
}
