namespace PROJETO.IHC.Domain.Entities
{
    public class QualificacaoColaborador : EntityBase
    {
        public QualificacaoColaborador() { }

        public QualificacaoColaborador(int id, int idColaborador, int idHabilidade) : base(id)
        {
            this.IdColaborador = idColaborador;
            this.IdHabilidade = idHabilidade;
        }

        public int IdColaborador { get; set; }

        public int IdHabilidade { get; set; }


        public virtual Colaborador Colaborador { get; set; }

        public virtual Habilidade Habilidade { get; set; }
    }
}
