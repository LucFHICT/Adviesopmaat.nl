using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdviesOpMaatASP.NET.Controllers;
using AdviesOpMaatASP.NET.Models;
using AdviesOpMaatASP.NET.Contexten;
using AdviesOpMaatASP.NET.Classes;
using AdviesOpMaatASP.NET.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;





namespace AdviesOpMaatASP.NET.Controllers
{
    public class GebruikerController : HomeController
    {
        GebruikerRepo repo = new GebruikerRepo(new GebruikerContext());
        public IActionResult Registreren()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Registreren(RegistrerenViewModel model)
        {
            if (ModelState.IsValid)
            {
                Gebruiker gebruiker = new Gebruiker(model.Gebruikersnaam, model.Wachtwoord);

                try
                {
                    repo.CreateGebruiker(gebruiker.Gebruikersnaam, gebruiker.Wachtwoord);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ExceptionHandler.WriteExceptionToFile(ex);
                    throw;
                }
            }
            return View();
        }


        
        public async Task<IActionResult> Uitloggen()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Inloggen()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inloggen(LoginViewModel model)
        {
            var tempgebruiker = repo.Login(model.Gebruikersnaam, model.Wachtwoord);
            Gebruiker gebruiker = tempgebruiker;
            try
            {
                if (gebruiker.Gebruikersnaam == null)
                {
                    ModelState.AddModelError(string.Empty, "Onjuiste inlog gegevens");

                    return View();
                }
                else
                {
                    var identity = new ClaimsIdentity(new[] //de gebruiker gaat in een claim (cookie)
                    {
                    new Claim(ClaimTypes.Role, gebruiker.Rol),
                    new Claim(ClaimTypes.GivenName, gebruiker.Gebruikersnaam),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity); //dit is de gebruiker

                    //de gebruiker gaat in de cookieschema
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);
                    //de user is nu authenticated 

                    if (identity.FindFirst(ClaimTypes.Role).Value == "Admin") // roltype uitgelezen uit cookie (test)
                    {
                        return RedirectToAction("Privacy", "Home");
                    }
                    else if (gebruiker.Rol == "Medewerker")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteExceptionToFile(ex);
                ModelState.AddModelError("Gebruikersnaam", "Controleer of de gebruikersnaam juist is");
                ModelState.AddModelError("Wachtwoord", "Controleer of het wachtwoord juist is");
                return RedirectToAction("Inloggen", "Gebruiker");
                throw;
            }
        }
    }
}

