using PROJETO.IHC.Domain.Enum;

namespace PROJETO.IHC.Domain.Entities
{
    public class Proposta : EntityBase
    {
        public Proposta() { }

        public Proposta(int id, string nomeProposta, string descricaoProposta, DateTime dtInicio, DateTime dtFim, decimal valorProposta, EStatusProposta statusProposta) : base(id)
        {
            this.NomeProposta = nomeProposta;
            this.DescricaoProposta = descricaoProposta;
            this.DtInicio = dtInicio;
            this.DtFim = dtFim;
            this.ValorProsposta = valorProposta;
            this.StatusProposta = statusProposta;
        }

        public string NomeProposta { get; set; }

        public string DescricaoProposta { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime DtFim { get; set; }

        public decimal ValorProsposta { get; set; }

        public EStatusProposta StatusProposta { get; set; }
    }
}
