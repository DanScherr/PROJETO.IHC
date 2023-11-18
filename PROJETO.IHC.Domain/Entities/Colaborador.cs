using PROJETO.IHC.Domain.Enum;

namespace PROJETO.IHC.Domain.Entities
{
    public class Colaborador : EntityBase
    {
        public Colaborador() { }

        public Colaborador(int id, string nome, DateTime dtNascimento, ESexo sexo, string documentoCPF, Contato contato, Endereco endereco) : base(id)
        {
            this.Nome = nome;
            this.DtNascimento = dtNascimento;
            this.Sexo = sexo;
            this.DocumentoCPF = documentoCPF;
            this.Contato = contato;
            this.Endereco = endereco;
        }

        public string Nome { get; set; }

        public DateTime DtNascimento { get; set; }

        public ESexo Sexo { get; set; }

        public string DocumentoCPF { get; set; }


        public virtual ICollection<Proposta> Propostas { get; set; }

        public virtual ICollection<QualificacaoColaborador> QualificacaoColaborador { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual Contato Contato { get; set; }
    }
}
