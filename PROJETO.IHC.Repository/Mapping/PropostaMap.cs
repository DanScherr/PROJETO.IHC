using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Repository.Mapping
{
    public class PropostaMap : IEntityTypeConfiguration<Proposta>
    {
        public void Configure(EntityTypeBuilder<Proposta> builder)
        {
            builder.ToTable("Proposta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeProposta).IsRequired();
            builder.Property(x => x.DescricaoProposta).IsRequired();
            builder.Property(x => x.DtInicio).IsRequired();
            builder.Property(x => x.DtFim).IsRequired();
            builder.Property(x => x.ValorProsposta).IsRequired();
            builder.Property(x => x.StatusProposta).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.HasMany(x => x.QualificacaoPropostas).WithOne(x => x.Proposta).HasForeignKey(x => x.IdProposta);
            builder.HasOne(x => x.Colaborador).WithMany(x => x.Propostas).HasForeignKey(x => x.IdColaborador);
            builder.HasOne(x => x.Projeto).WithMany(x => x.Propostas).HasForeignKey(x => x.IdProjeto);
        }
    }
}
