using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdviesOpMaatASP.NET.Models
{
    public class RegistrerenViewModel
    {
        [Required(ErrorMessage = "Vul hier uw gebruikersnaam in")]
        public string Gebruikersnaam { get; set; }

        [Required(ErrorMessage = "Voer een wachtwoord in")]
        [RegularExpression(pattern: @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{5,}$", ErrorMessage = "Wachtwoord is minstens 5 tekens lang en bevat minstens 1 hoofdletter, 1 kleine letter en één cijfer")]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Herhaal wachtwoord")]
        [Compare("Wachtwoord",
        ErrorMessage = "Wachtwoord komt niet overeen.")]
        public string Wachtwoord2 { get; set; }

    }
}
