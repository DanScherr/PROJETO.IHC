namespace PROJETO.IHC.Domain.DTOs.Habilidade
{
    public class HabilidadeOutputDTO
    {
        public int Id { get; set; }

        public string NomeHabilidade { get; set; }

        public string DescricaoHabilidade { get; set; }

        public string ExeperienciaHabilidade { get; set; }

        public bool Ativo { get; set; }
    }
}
