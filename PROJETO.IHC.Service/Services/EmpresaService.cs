using PROJETO.IHC.Domain.DTOs.Colaborador;
using PROJETO.IHC.Domain.DTOs.Empresa;
using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public EmpresaOutputDTO GetEmpresaById(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var empresa = _empresaRepository.ObterPorId(id);

            if (empresa == null || !empresa.Ativo)
                throw new KeyNotFoundException($"Empresa com Id: {id} não encontrado");

            return new EmpresaOutputDTO()
            {
                Id = empresa.Id,
                NomeEmpresa = empresa.NomeEmpresa,
                DocumentoCNPJ = empresa.DocumentoCNPJ,
                SiteEmpresa = empresa.SiteEmpresa,
                Telefone = empresa.Telefone,
                Email = empresa.Email,
                Logradouro = empresa.Logradouro,
                Numero = empresa.Numero,
                Bairro = empresa.Bairro,
                Cidade = empresa.Cidade,
                UF = empresa.UF,
                CEP = empresa.CEP,
                Ativo = empresa.Ativo
            };
        }

        public List<EmpresaOutputDTO> GetAllEmpresas()
        {
            var listEmpresa = _empresaRepository.ObterTodos();

            return listEmpresa.Select(x =>
            {
                return new EmpresaOutputDTO()
                {
                    Id = x.Id,
                    NomeEmpresa = x.NomeEmpresa,
                    DocumentoCNPJ = x.DocumentoCNPJ,
                    SiteEmpresa = x.SiteEmpresa,
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

        public EmpresaOutputDTO InsertEmpresa(EmpresaInsertDTO empresaInsertDTO)
        {
            var empresa = new Empresa()
            {
                NomeEmpresa = empresaInsertDTO.NomeEmpresa,
                DocumentoCNPJ = empresaInsertDTO.DocumentoCNPJ,
                SiteEmpresa = empresaInsertDTO.SiteEmpresa,
                Email = empresaInsertDTO.Email,
                Telefone = empresaInsertDTO.Telefone,
                Logradouro = empresaInsertDTO.Logradouro,
                Numero = empresaInsertDTO.Numero,
                Bairro = empresaInsertDTO.Bairro,
                Cidade = empresaInsertDTO.Cidade,
                UF = empresaInsertDTO.UF,
                CEP = empresaInsertDTO.CEP
            };

            empresa.Ativar();

            _empresaRepository.Inserir(empresa);

            if (empresa.Id == 0)
                throw new NullReferenceException("Falha ao inserir Empresa");

            return new EmpresaOutputDTO()
            {
                Id = empresa.Id,
                NomeEmpresa = empresa.NomeEmpresa,
                DocumentoCNPJ = empresa.DocumentoCNPJ,
                SiteEmpresa = empresa.SiteEmpresa,
                Email = empresa.Email,
                Telefone = empresa.Telefone,
                Logradouro = empresa.Logradouro,
                Numero = empresa.Numero,
                Bairro = empresa.Bairro,
                Cidade = empresa.Cidade,
                UF = empresa.UF,
                CEP = empresa.CEP,
                Ativo = empresa.Ativo
            };
        }

        public EmpresaOutputDTO UpdateEmpresa(EmpresaUpdateDTO empresaUpdateDTO)
        {
            this.GetEmpresaById(empresaUpdateDTO.Id);

            var empresa = new Empresa()
            {
                Id= empresaUpdateDTO.Id,
                NomeEmpresa = empresaUpdateDTO.NomeEmpresa,
                DocumentoCNPJ = empresaUpdateDTO.DocumentoCNPJ,
                SiteEmpresa = empresaUpdateDTO.SiteEmpresa,
                Email = empresaUpdateDTO.Email,
                Telefone = empresaUpdateDTO.Telefone,
                Logradouro = empresaUpdateDTO.Logradouro,
                Numero = empresaUpdateDTO.Numero,
                Bairro = empresaUpdateDTO.Bairro,
                Cidade = empresaUpdateDTO.Cidade,
                UF = empresaUpdateDTO.UF,
                CEP = empresaUpdateDTO.CEP
            };

            _empresaRepository.Alterar(empresa);

            return new EmpresaOutputDTO()
            {
                Id = empresa.Id,
                NomeEmpresa = empresa.NomeEmpresa,
                DocumentoCNPJ = empresa.DocumentoCNPJ,
                SiteEmpresa = empresa.SiteEmpresa,
                Email = empresa.Email,
                Telefone = empresa.Telefone,
                Logradouro = empresa.Logradouro,
                Numero = empresa.Numero,
                Bairro = empresa.Bairro,
                Cidade = empresa.Cidade,
                UF = empresa.UF,
                CEP = empresa.CEP,
                Ativo = empresa.Ativo
            };
        }

        public bool DeleteEmpresa(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var isDelete = _empresaRepository.Deletar(id);

            if (!isDelete)
                throw new KeyNotFoundException($"Empresa com Id: {id} não encontrada");

            return isDelete;
        }
    }
}
