namespace PROJETO.IHC.Domain.Entities
{
    public class Empresa : EntityBase
    {
        public Empresa() { }

        public Empresa(int id,
                       string nomeEmpresa, 
                       string documentoCNPJ, 
                       string siteEmpresa, 
                       string telefone, 
                       string email, 
                       string logradouro, 
                       string numero, 
                       string bairro, 
                       string cidade, 
                       string uF, 
                       string cEP) : base(id)
        {
            this.NomeEmpresa = nomeEmpresa;
            this.DocumentoCNPJ = documentoCNPJ;
            this.SiteEmpresa = siteEmpresa;
            this.Telefone = telefone;
            this.Email = email;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.UF = uF;
            this.CEP = cEP;
        }

        public string NomeEmpresa { get; set; }

        public string DocumentoCNPJ { get; set; }

        public string SiteEmpresa { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }


        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
