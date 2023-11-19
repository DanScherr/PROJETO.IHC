using PROJETO.IHC.Domain.DTOs.Colaborador;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public List<ColaboradorOutputDTO> GetAllColaboradores()
        {
            var listColaboradores = _colaboradorRepository.ObterTodos();

            return listColaboradores.Select(x =>
            {
                return new ColaboradorOutputDTO()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DtNascimento = x.DtNascimento,
                    Sexo = x.Sexo,
                    DocumentoCPF = x.DocumentoCPF,
                    Telefone = x.Telefone,
                    Email = x.Email,
                    Logradouro = x.Logradouro,
                    Numero = x.Numero,
                    Bairro = x.Bairro,
                    Cidade = x.Cidade,
                    UF = x.UF,
                    CEP = x.CEP,
                    Ativo = x.Ativo
                };
            }).ToList();
        }
    }
}
