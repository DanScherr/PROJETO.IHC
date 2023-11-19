using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Repository.Mapping
{
    public class QualificacaoColaboradorMap : IEntityTypeConfiguration<QualificacaoColaborador>
    {
        public void Configure(EntityTypeBuilder<QualificacaoColaborador> builder)
        {
            builder.ToTable("QualificacaoColaborador");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ativo);
            builder.HasOne(x => x.Colaborador).WithMany(x => x.QualificacaoColaborador).HasForeignKey(x => x.IdColaborador);
            builder.HasOne(x => x.Habilidade).WithMany(x => x.QualificacaoColaboradores).HasForeignKey(x => x.IdColaborador);
        }
    }
}
