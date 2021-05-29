using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMedia.Models
{
    public class Aluno : Entity
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(200,ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres",MinimumLength =2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Matrícula")]
        public string Matricula { get; set; }

        public Turma Turma { get; set; }

        public Guid TurmaId { get; set; }
    }
}

