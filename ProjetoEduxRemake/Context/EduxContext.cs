using Microsoft.EntityFrameworkCore;
using ProjetoEduxRemake.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduxRemake.Context
{
    public class EduxContext : DbContext
    {
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Dica> Dicas { get; set; }
        public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<ObjetivoAluno> ObjetivosAlunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Ranking> Rankings { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9K8CGCB\SQLEXPRESS;Initial Catalog=NewProjetoEduxRemake;Persist Security Info=True;User ID=sa;Password=sa132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curtida>()
            .HasOne(b => b.Usuario)
            .WithMany(a => a.Curtidas)
            .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }



    }
}
