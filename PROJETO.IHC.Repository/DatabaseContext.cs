using Microsoft.EntityFrameworkCore;
using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Repository.Mapping;

namespace PROJETO.IHC.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Habilidade> Habilidade { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Proposta> Proposta { get; set; }
        public DbSet<QualificacaoColaborador> QualificacaoColaborador { get; set; }
        public DbSet<QualificacaoProposta> QualificacaoProposta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"string de conexão");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>(new ColaboradorMap().Configure);
            modelBuilder.Entity<Empresa>(new EmpresaMap().Configure);
            modelBuilder.Entity<Habilidade>(new HabilidadeMap().Configure);
            modelBuilder.Entity<Projeto>(new ProjetoMap().Configure);
            modelBuilder.Entity<Proposta>(new PropostaMap().Configure);
            modelBuilder.Entity<QualificacaoColaborador>(new QualificacaoColaboradorMap().Configure);
            modelBuilder.Entity<QualificacaoProposta>(new QualificacaoPropostaMap().Configure);

            base.OnModelCreating(modelBuilder);

            // carregar seeds
        }
    }
}
