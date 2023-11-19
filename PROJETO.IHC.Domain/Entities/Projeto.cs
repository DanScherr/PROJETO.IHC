namespace PROJETO.IHC.Domain.Entities
{
    public class Projeto : EntityBase
    {
        public Projeto() { }

        public Projeto(int id,
                       string nomeProjeto, 
                       string descricaoProjeto, 
                       string logradouro, 
                       string numero, 
                       string bairro, 
                       string cidade, 
                       string uF, 
                       string cEP) : base(id)
        {
            this.NomeProjeto = nomeProjeto;
            this.DescricaoProjeto = descricaoProjeto;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.UF = uF;
            this.CEP = cEP;
        }

        public string NomeProjeto { get; set; }

        public string DescricaoProjeto { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }


        public virtual ICollection<Proposta> Propostas { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
