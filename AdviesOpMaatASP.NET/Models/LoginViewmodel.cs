using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdviesOpMaatASP.NET.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kan niet inloggen zonder gebruikersnaam")]
        [Display(Name = "Gebruikersnaam")]
        public string Gebruikersnaam { get; set; }

        [Required(ErrorMessage = "Kan niet inloggen zonder wachtwoord")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Wachtwoord { get; set; }
    }
}
