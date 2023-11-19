namespace PROJETO.IHC.Domain.DTOs.Projeto
{
    public class ProjetoUpdateDTO
    {
        public int Id { get; set; }

        public string NomeProjeto { get; set; }

        public string DescricaoProjeto { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }

        public int IdEmpresa { get; set; }
    }
}
