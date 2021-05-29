using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppMedia.Models
{
    public class Turma : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Curso { get; set; }
        
    }
}
