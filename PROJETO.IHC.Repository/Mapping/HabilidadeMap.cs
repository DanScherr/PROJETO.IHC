using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Repository.Mapping
{
    public class HabilidadeMap : IEntityTypeConfiguration<Habilidade>
    {
        public void Configure(EntityTypeBuilder<Habilidade> builder)
        {
            builder.ToTable("Habilidade");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeHabilidade).IsRequired();
            builder.Property(x => x.DescricaoHabilidade).IsRequired();
            builder.Property(x => x.ExeperienciaHabilidade).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.HasMany(x => x.QualificacaoColaboradores).WithOne(x => x.Habilidade).HasForeignKey(x => x.IdHabilidade);
            builder.HasMany(x => x.QualificacaoPropostas).WithOne(x => x.Habilidade).HasForeignKey(x => x.IdHabilidade);
        }
    }
}
