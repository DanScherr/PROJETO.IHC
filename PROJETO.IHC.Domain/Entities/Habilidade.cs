namespace PROJETO.IHC.Domain.Entities
{
    public class Habilidade : EntityBase
    {
        public Habilidade() { }

        public Habilidade(int id, string nomeHabilidade, string descricaoHabilidade, string exeperienciaHabilidade) : base(id)
        {
            this.NomeHabilidade = nomeHabilidade;
            this.DescricaoHabilidade = descricaoHabilidade;
            this.ExeperienciaHabilidade = exeperienciaHabilidade;
        }

        public string NomeHabilidade { get; set; }

        public string DescricaoHabilidade { get; set; }

        public string ExeperienciaHabilidade { get; set; }


        public virtual ICollection<QualificacaoColaborador> QualificacaoColaboradores { get; set; }

        public virtual ICollection<QualificacaoProposta> QualificacaoPropostas { get; set; }

    }
}
