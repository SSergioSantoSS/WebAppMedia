using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMedia.Models
{
    public class Nota : Entity
    {
        public double Nota01 { get; set; }
        public double Nota02 { get; set; }
        public double Nota03 { get; set; }

        [DisplayName("Prova Final")]
       
        public double Pf { get; set; }
        
        public double Premio{ get; set; }

        [DisplayName("Média")]
       
        public decimal Media { get; set; }

        public Turma Turma { get; set; }

        public Aluno Aluno{ get; set; }

        public Guid TurmaId { get; set; }

        public Guid AlunoId { get; set; }
        
        public string SituacaoFinal { get; set; }





    }
}
