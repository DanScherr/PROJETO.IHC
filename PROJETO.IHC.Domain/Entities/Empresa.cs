namespace PROJETO.IHC.Domain.Entities
{
    public class Empresa : EntityBase
    {
        public Empresa() { }

        public Empresa(int id, string nomeEmpres, string documentoCNPJ, string siteEmpresa, Endereco endereco, Contato contato) : base(id)
        {
            this.NomeEmpresa = nomeEmpres;
            this.DocumentoCNPJ = documentoCNPJ;
            this.SiteEmpresa = siteEmpresa;
            this.Endereco = endereco;
            this.Contato = contato;
        }

        public string NomeEmpresa { get; set; }

        public string DocumentoCNPJ { get; set; }

        public string SiteEmpresa { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual Contato Contato { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
