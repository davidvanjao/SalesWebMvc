using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]//Verifica se o campo digitado é um e-mail válido.
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]//
        public string Password { get; set; }
    }
}
