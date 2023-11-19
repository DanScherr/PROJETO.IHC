using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJETO.IHC.Domain.Entities;

namespace PROJETO.IHC.Repository.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeEmpresa).IsRequired();
            builder.Property(x => x.DocumentoCNPJ).IsRequired();
            builder.Property(x => x.SiteEmpresa).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Logradouro).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.UF).IsRequired();
            builder.Property(x => x.CEP).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.HasMany(x => x.Projetos).WithOne(x => x.Empresa).HasForeignKey(x => x.IdEmpresa);
        }
    }
}
