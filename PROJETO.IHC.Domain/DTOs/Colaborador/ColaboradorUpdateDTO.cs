using PROJETO.IHC.Domain.Enum;

namespace PROJETO.IHC.Domain.DTOs.Colaborador
{
    public class ColaboradorUpdateDTO
    {
        public int Id { get; set; }

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
    }
}
