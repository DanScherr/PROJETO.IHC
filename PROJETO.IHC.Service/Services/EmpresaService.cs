using PROJETO.IHC.Domain.DTOs;
using PROJETO.IHC.Domain.DTOs.Empresa;
using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IColaboradorRepository _colaboradorRepository;

        public EmpresaService(IEmpresaRepository empresaRepository, IColaboradorRepository colaboradorRepository)
        {
            _empresaRepository = empresaRepository;
            _colaboradorRepository = colaboradorRepository;
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
                Senha = empresaInsertDTO.Senha,
                Telefone = empresaInsertDTO.Telefone,
                Logradouro = empresaInsertDTO.Logradouro,
                Numero = empresaInsertDTO.Numero,
                Bairro = empresaInsertDTO.Bairro,
                Cidade = empresaInsertDTO.Cidade,
                UF = empresaInsertDTO.UF,
                CEP = empresaInsertDTO.CEP
            };

            if (this.ValidaEmpresaEmailExistente(empresa.Email) || this.ValidaColaboradorEmailExistente(empresa.Email))
                throw new ArgumentException("Email informado já existente!");

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
            var empresaOutputDTO = this.GetEmpresaById(empresaUpdateDTO.Id);

            var empresa = new Empresa()
            {
                Id = empresaUpdateDTO.Id,
                NomeEmpresa = empresaUpdateDTO.NomeEmpresa,
                DocumentoCNPJ = empresaUpdateDTO.DocumentoCNPJ,
                SiteEmpresa = empresaUpdateDTO.SiteEmpresa,
                Email = empresaUpdateDTO.Email,
                Senha = empresaUpdateDTO.Senha,
                Telefone = empresaUpdateDTO.Telefone,
                Logradouro = empresaUpdateDTO.Logradouro,
                Numero = empresaUpdateDTO.Numero,
                Bairro = empresaUpdateDTO.Bairro,
                Cidade = empresaUpdateDTO.Cidade,
                UF = empresaUpdateDTO.UF,
                CEP = empresaUpdateDTO.CEP
            };

            if (empresaOutputDTO.Email.ToUpper() != empresa.Email.ToUpper())
                if (this.ValidaEmpresaEmailExistente(empresa.Email) || this.ValidaColaboradorEmailExistente(empresa.Email))
                    throw new ArgumentException("Email informado já existente!");

            empresa.Ativar();

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

        public int LoginEmpresa(LoginDTO loginDTO)
        {
            var empresa = _empresaRepository.LoginEmpresa(loginDTO.Email, loginDTO.Senha);

            if (empresa == null)
                return 0;

            return empresa.Id;
        }

        public bool ValidaEmpresaEmailExistente(string email)
        {
            var empresa = _empresaRepository.GetEmpresaByEmail(email);
            return empresa != null;
        }

        public bool ValidaColaboradorEmailExistente(string email)
        {
            var colaborador = _colaboradorRepository.GetColaboradorByEmail(email);
            return colaborador != null;
        }
    }
}
