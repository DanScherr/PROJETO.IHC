namespace PROJETO.IHC.Domain.DTOs.Empresa
{
    public class EmpresaOutputDTO
    {
        public int Id { get; set; }

        public string NomeEmpresa { get; set; }

        public string DocumentoCNPJ { get; set; }

        public string SiteEmpresa { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }

        public bool Ativo { get; set; }
    }
}
