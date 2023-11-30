using PROJETO.IHC.Domain.DTOs.Proposta;
using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;

        public PropostaService(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public PropostaOutputDTO GetPropostaById(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var proposta = _propostaRepository.ObterPorId(id);

            if (proposta == null || !proposta.Ativo)
                throw new KeyNotFoundException($"Proposta com Id: {id} não encontrado");

            return new PropostaOutputDTO()
            {
                Id = proposta.Id,
                NomeProposta = proposta.NomeProposta,
                DescricaoProposta = proposta.DescricaoProposta,
                ValorProsposta = proposta.ValorProsposta,
                StatusProposta = proposta.StatusProposta,
                DtInicio = proposta.DtInicio.ToString(),
                DtFim = proposta.DtFim.ToString(),
                IdColaborador = proposta.IdColaborador,
                IdProjeto = proposta.IdProjeto,
                Ativo = proposta.Ativo
            };
        }

        public List<PropostaOutputDTO> GetAllPropostas()
        {
            var listPropostas = _propostaRepository.ObterTodos();

            return listPropostas.Select(x =>
            {
                return new PropostaOutputDTO()
                {
                    Id = x.Id,
                    NomeProposta = x.NomeProposta,
                    DescricaoProposta = x.DescricaoProposta,
                    ValorProsposta = x.ValorProsposta,
                    StatusProposta = x.StatusProposta,
                    DtInicio = x.DtInicio.ToString(),
                    DtFim = x.DtFim.ToString(),
                    IdColaborador = x.IdColaborador,
                    IdProjeto = x.IdProjeto,
                    Ativo = x.Ativo
                };
            }).ToList();
        }

        public PropostaOutputDTO InsertProposta(PropostaInsertDTO propostaInsertDTO)
        {
            var proposta = new Proposta()
            {
                NomeProposta = propostaInsertDTO.NomeProposta,
                DescricaoProposta = propostaInsertDTO.DescricaoProposta,
                ValorProsposta = propostaInsertDTO.ValorProsposta,
                StatusProposta = propostaInsertDTO.StatusProposta,
                DtInicio = Convert.ToDateTime(propostaInsertDTO.DtInicio),
                DtFim = Convert.ToDateTime(propostaInsertDTO.DtFim),
                IdColaborador = propostaInsertDTO.IdColaborador,
                IdProjeto = propostaInsertDTO.IdProjeto
            };

            proposta.Ativar();

            _propostaRepository.Inserir(proposta);

            if (proposta.Id == 0)
                throw new NullReferenceException("Falha ao inserir Proposta");

            return new PropostaOutputDTO()
            {
                Id = proposta.Id,
                NomeProposta = proposta.NomeProposta,
                DescricaoProposta = proposta.DescricaoProposta,
                ValorProsposta = proposta.ValorProsposta,
                StatusProposta = proposta.StatusProposta,
                DtInicio = proposta.DtInicio.ToString(),
                DtFim = proposta.DtFim.ToString(),
                IdColaborador = proposta.IdColaborador,
                IdProjeto = proposta.IdProjeto,
                Ativo = proposta.Ativo
            };
        }

        public PropostaOutputDTO UpdateProposta(PropostaUpdateDTO propostaUpdateDTO)
        {
            this.GetPropostaById(propostaUpdateDTO.Id);

            var proposta = new Proposta()
            {
                Id = propostaUpdateDTO.Id,
                NomeProposta = propostaUpdateDTO.NomeProposta,
                DescricaoProposta = propostaUpdateDTO.DescricaoProposta,
                ValorProsposta = propostaUpdateDTO.ValorProsposta,
                StatusProposta = propostaUpdateDTO.StatusProposta,
                DtInicio = Convert.ToDateTime(propostaUpdateDTO.DtInicio),
                DtFim = Convert.ToDateTime(propostaUpdateDTO.DtFim),
                IdColaborador = propostaUpdateDTO.IdColaborador,
                IdProjeto = propostaUpdateDTO.IdProjeto
            };

            _propostaRepository.Alterar(proposta);

            return new PropostaOutputDTO()
            {
                Id = proposta.Id,
                NomeProposta = proposta.NomeProposta,
                DescricaoProposta = proposta.DescricaoProposta,
                ValorProsposta = proposta.ValorProsposta,
                StatusProposta = proposta.StatusProposta,
                DtInicio = proposta.DtInicio.ToString(),
                DtFim = proposta.DtFim.ToString(),
                IdColaborador = proposta.IdColaborador,
                IdProjeto = proposta.IdProjeto,
                Ativo = proposta.Ativo
            };
        }

        public bool DeleteProposta(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var isDelete = _propostaRepository.Deletar(id);

            if (!isDelete)
                throw new KeyNotFoundException($"Proposta com Id: {id} não encontrada");

            return isDelete;
        }
    }
}
