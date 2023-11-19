using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Repository.Mapping
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaborador");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.DtNascimento).IsRequired();
            builder.Property(x => x.Sexo).IsRequired();
            builder.Property(x => x.DocumentoCPF).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Logradouro).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.UF).IsRequired();
            builder.Property(x => x.CEP).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.HasMany(x => x.Propostas).WithOne(x => x.Colaborador).HasForeignKey(x => x.IdColaborador);
            builder.HasMany(x => x.QualificacaoColaborador).WithOne(x => x.Colaborador).HasForeignKey(x => x.IdColaborador);
        }
    }
}
