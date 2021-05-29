using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppMedia.Models;

namespace WebAppMedia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }
}
