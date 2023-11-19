using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Repository.Mapping
{
    public class ProjetoMap : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeProjeto).IsRequired();
            builder.Property(x => x.DescricaoProjeto).IsRequired();
            builder.Property(x => x.Logradouro).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.UF).IsRequired();
            builder.Property(x => x.CEP).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.HasMany(x => x.Propostas).WithOne(x => x.Projeto).HasForeignKey(x => x.IdProjeto);
            builder.HasOne(x => x.Empresa).WithMany(x => x.Projetos).HasForeignKey(x => x.IdEmpresa);
        }
    }
}
