namespace PROJETO.IHC.Domain.Entities
{
    public class QualificacaoProposta : EntityBase
    {
        public QualificacaoProposta() { }

        public QualificacaoProposta(int id, int idProposta, int idHabilidade) : base(id)
        {
            this.IdProposta = idProposta;
            this.IdHabilidade = idHabilidade;
        }

        public int IdProposta { get; set; }

        public int IdHabilidade { get; set; }


        public virtual Proposta Proposta { get; set; }

        public virtual Habilidade Habilidade { get; set; }
    }
}
