using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Repository.Mapping
{
    public class QualificacaoPropostaMap : IEntityTypeConfiguration<QualificacaoProposta>
    {
        public void Configure(EntityTypeBuilder<QualificacaoProposta> builder)
        {
            builder.ToTable("QualificacaoProposta");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ativo);
            builder.HasOne(x => x.Proposta).WithMany(x => x.QualificacaoPropostas).HasForeignKey(x => x.IdProposta);
            builder.HasOne(x => x.Habilidade).WithMany(x => x.QualificacaoPropostas).HasForeignKey(x => x.IdProposta);
        }
    }
}
