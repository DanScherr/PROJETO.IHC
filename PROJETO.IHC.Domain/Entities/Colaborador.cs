using PROJETO.IHC.Domain.Enum;

namespace PROJETO.IHC.Domain.Entities
{
    public class Colaborador : EntityBase
    {
        public Colaborador() { }

        public Colaborador(int id,
                           string nome, 
                           DateTime dtNascimento, 
                           ESexo sexo, 
                           string documentoCPF, 
                           string telefone, 
                           string email, 
                           string logradouro, 
                           string numero,
                           string bairro,
                           string cidade, 
                           string uF, 
                           string cEP) : base(id)
        {
            this.Nome = nome;
            this.DtNascimento = dtNascimento;
            this.Sexo = sexo;
            this.DocumentoCPF = documentoCPF;
            this.Telefone = telefone;
            this.Email = email;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.UF = uF;
            this.CEP = cEP;
        }

        public string Nome { get; set; }

        public DateTime DtNascimento { get; set; }

        public ESexo Sexo { get; set; }

        public string DocumentoCPF { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }


        public virtual ICollection<Proposta> Propostas { get; set; }

        public virtual ICollection<QualificacaoColaborador> QualificacaoColaborador { get; set; }
    }
}
