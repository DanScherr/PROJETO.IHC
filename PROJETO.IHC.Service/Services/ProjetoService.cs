using PROJETO.IHC.Domain.DTOs.Colaborador;
using PROJETO.IHC.Domain.DTOs.Projeto;
using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public ProjetoOutputDTO GetProjetoById(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var projeto = _projetoRepository.ObterPorId(id);

            if (projeto == null || !projeto.Ativo)
                throw new KeyNotFoundException($"Projeto com Id: {id} não encontrado");

            return new ProjetoOutputDTO()
            {
                Id = projeto.Id,
                NomeProjeto = projeto.NomeProjeto,
                DescricaoProjeto = projeto.DescricaoProjeto,
                IdEmpresa = projeto.IdEmpresa,
                Logradouro = projeto.Logradouro,
                Numero = projeto.Numero,
                Bairro = projeto.Bairro,
                Cidade = projeto.Cidade,
                UF = projeto.UF,
                CEP = projeto.CEP,
                Ativo = projeto.Ativo
            };
        }

        public List<ProjetoOutputDTO> GetAllProjetos()
        {
            var listProjetos = _projetoRepository.ObterTodos();

            return listProjetos.Select(x =>
            {
                return new ProjetoOutputDTO()
                {
                    Id = x.Id,
                    NomeProjeto = x.NomeProjeto,
                    DescricaoProjeto = x.DescricaoProjeto,
                    IdEmpresa = x.IdEmpresa,
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

        public ProjetoOutputDTO InsertProjeto(ProjetoInsertDTO projetoInsertDTO)
        {
            var projeto = new Projeto()
            {
                NomeProjeto = projetoInsertDTO.NomeProjeto,
                DescricaoProjeto = projetoInsertDTO.DescricaoProjeto,
                IdEmpresa = projetoInsertDTO.IdEmpresa,
                Logradouro = projetoInsertDTO.Logradouro,
                Numero = projetoInsertDTO.Numero,
                Bairro = projetoInsertDTO.Bairro,
                Cidade = projetoInsertDTO.Cidade,
                UF = projetoInsertDTO.UF,
                CEP = projetoInsertDTO.CEP
            };

            projeto.Ativar();

            _projetoRepository.Inserir(projeto);

            if (projeto.Id == 0)
                throw new NullReferenceException("Falha ao inserir Projeto");

            return new ProjetoOutputDTO()
            {
                Id = projeto.Id,
                NomeProjeto = projeto.NomeProjeto,
                DescricaoProjeto = projeto.DescricaoProjeto,
                IdEmpresa = projeto.IdEmpresa,
                Logradouro = projeto.Logradouro,
                Numero = projeto.Numero,
                Bairro = projeto.Bairro,
                Cidade = projeto.Cidade,
                UF = projeto.UF,
                CEP = projeto.CEP,
                Ativo = projeto.Ativo
            };
        }

        public ProjetoOutputDTO UpdateProjeto(ProjetoUpdateDTO projetoUpdateDTO)
        {
            this.GetProjetoById(projetoUpdateDTO.Id);

            var projeto = new Projeto()
            {
                Id = projetoUpdateDTO.Id,
                NomeProjeto = projetoUpdateDTO.NomeProjeto,
                DescricaoProjeto = projetoUpdateDTO.DescricaoProjeto,
                IdEmpresa = projetoUpdateDTO.IdEmpresa,
                Logradouro = projetoUpdateDTO.Logradouro,
                Numero = projetoUpdateDTO.Numero,
                Bairro = projetoUpdateDTO.Bairro,
                Cidade = projetoUpdateDTO.Cidade,
                UF = projetoUpdateDTO.UF,
                CEP = projetoUpdateDTO.CEP
            };

            _projetoRepository.Alterar(projeto);

            return new ProjetoOutputDTO()
            {
                Id = projeto.Id,
                NomeProjeto = projeto.NomeProjeto,
                DescricaoProjeto = projeto.DescricaoProjeto,
                IdEmpresa = projeto.IdEmpresa,
                Logradouro = projeto.Logradouro,
                Numero = projeto.Numero,
                Bairro = projeto.Bairro,
                Cidade = projeto.Cidade,
                UF = projeto.UF,
                CEP = projeto.CEP,
                Ativo = projeto.Ativo
            };
        }

        public bool DeleteProjeto(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var isDelete = _projetoRepository.Deletar(id);

            if (!isDelete)
                throw new KeyNotFoundException($"Projeto com Id: {id} não encontrada");

            return isDelete;
        }
    }
}
