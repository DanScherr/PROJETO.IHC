using PROJETO.IHC.Domain.Enum;

namespace PROJETO.IHC.Domain.DTOs.Proposta
{
    public class PropostaUpdateDTO
    {
        public int Id { get; set; }

        public string NomeProposta { get; set; }

        public string DescricaoProposta { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime DtFim { get; set; }

        public decimal ValorProsposta { get; set; }

        public EStatusProposta StatusProposta { get; set; }

        public int IdColaborador { get; set; }

        public int IdProjeto { get; set; }
    }
}
