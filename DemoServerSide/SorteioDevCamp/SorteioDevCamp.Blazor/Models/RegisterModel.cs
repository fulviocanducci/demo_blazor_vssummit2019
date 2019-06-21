using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SorteioDevCamp.Blazor.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "O campo NOME é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo NOME deve ter até 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo EMAIL é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Email deve ter até 100 caracteres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo EMPRESA é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo EMPRESA deve ter até 100 caracteres")]
        public string Company { get; set; }

        [Required(ErrorMessage = "O campo CARGO é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo CARGO deve ter até 50 caracteres")]
        public string Role { get; set; }
    }
}
