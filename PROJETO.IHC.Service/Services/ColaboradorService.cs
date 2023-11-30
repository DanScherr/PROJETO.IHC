using PROJETO.IHC.Domain.DTOs;
using PROJETO.IHC.Domain.DTOs.Colaborador;
using PROJETO.IHC.Domain.Entities;
using PROJETO.IHC.Domain.Interfaces.Repositories;
using PROJETO.IHC.Domain.Interfaces.Services;

namespace PROJETO.IHC.Service.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository, IEmpresaRepository empresaRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _empresaRepository = empresaRepository;
        }

        public ColaboradorOutputDTO GetColaboradorById(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var colaborador = _colaboradorRepository.ObterPorId(id);

            if (colaborador == null || !colaborador.Ativo)
                throw new KeyNotFoundException($"Colaborador com Id: {id} não encontrado");

            return new ColaboradorOutputDTO()
            {
                Id = colaborador.Id,
                Nome = colaborador.Nome,
                DtNascimento = colaborador.DtNascimento.ToString(),
                Sexo = colaborador.Sexo,
                DocumentoCPF = colaborador.DocumentoCPF,
                Telefone = colaborador.Telefone,
                Email = colaborador.Email,
                Logradouro = colaborador.Logradouro,
                Numero = colaborador.Numero,
                Bairro = colaborador.Bairro,
                Cidade = colaborador.Cidade,
                UF = colaborador.UF,
                CEP = colaborador.CEP,
                Ativo = colaborador.Ativo
            };
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
                    DtNascimento = x.DtNascimento.ToString(),
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

        public ColaboradorOutputDTO InsertColaborador(ColaboradorInsertDTO colaboradorInsertDTO)
        {
            var colaborador = new Colaborador()
            {
                Nome = colaboradorInsertDTO.Nome,
                DocumentoCPF = colaboradorInsertDTO.DocumentoCPF,
                DtNascimento = Convert.ToDateTime(colaboradorInsertDTO.DtNascimento),
                Sexo = colaboradorInsertDTO.Sexo,
                Email = colaboradorInsertDTO.Email,
                Senha = colaboradorInsertDTO.Senha,
                Telefone = colaboradorInsertDTO.Telefone,
                Logradouro = colaboradorInsertDTO.Logradouro,
                Numero = colaboradorInsertDTO.Numero,
                Bairro = colaboradorInsertDTO.Bairro,
                Cidade = colaboradorInsertDTO.Cidade,
                UF = colaboradorInsertDTO.UF,
                CEP = colaboradorInsertDTO.CEP
            };

            if (this.ValidaColaboradorEmailExistente(colaborador.Email) || this.ValidaEmpresaEmailExistente(colaborador.Email))
                throw new ArgumentException("Email informado já existente!");

            colaborador.Ativar();

            _colaboradorRepository.Inserir(colaborador);

            if (colaborador.Id == 0)
                throw new NullReferenceException("Falha ao inserir Colaborador");

            return new ColaboradorOutputDTO()
            {
                Id = colaborador.Id,
                Nome = colaborador.Nome,
                DocumentoCPF = colaborador.DocumentoCPF,
                DtNascimento = colaborador.DtNascimento.ToString(),
                Sexo = colaborador.Sexo,
                Email = colaborador.Email,
                Telefone = colaborador.Telefone,
                Logradouro = colaborador.Logradouro,
                Numero = colaborador.Numero,
                Bairro = colaborador.Bairro,
                Cidade = colaborador.Cidade,
                UF = colaborador.UF,
                CEP = colaborador.CEP,
                Ativo = colaborador.Ativo
            };
        }

        public ColaboradorOutputDTO UpdateColaborador(ColaboradorUpdateDTO colaboradorUpdateDTO)
        {
            var colaboradorOutputDTO = this.GetColaboradorById(colaboradorUpdateDTO.Id);

            var colaborador = new Colaborador()
            {
                Id = colaboradorUpdateDTO.Id,
                Nome = colaboradorUpdateDTO.Nome,
                DocumentoCPF = colaboradorUpdateDTO.DocumentoCPF,
                DtNascimento = Convert.ToDateTime(colaboradorUpdateDTO.DtNascimento),
                Sexo = colaboradorUpdateDTO.Sexo,
                Email = colaboradorUpdateDTO.Email,
                Senha = colaboradorUpdateDTO.Senha,
                Telefone = colaboradorUpdateDTO.Telefone,
                Logradouro = colaboradorUpdateDTO.Logradouro,
                Numero = colaboradorUpdateDTO.Numero,
                Bairro = colaboradorUpdateDTO.Bairro,
                Cidade = colaboradorUpdateDTO.Cidade,
                UF = colaboradorUpdateDTO.UF,
                CEP = colaboradorUpdateDTO.CEP
            };

            colaborador.Ativar();

            if (colaboradorOutputDTO.Email.ToUpper() != colaborador.Email.ToUpper())
                if (this.ValidaColaboradorEmailExistente(colaborador.Email) || this.ValidaEmpresaEmailExistente(colaborador.Email))
                    throw new ArgumentException("Email informado já existente!");

            _colaboradorRepository.Alterar(colaborador);

            return new ColaboradorOutputDTO()
            {
                Id = colaborador.Id,
                Nome = colaborador.Nome,
                DocumentoCPF = colaborador.DocumentoCPF,
                DtNascimento = colaborador.DtNascimento.ToString(),
                Sexo = colaborador.Sexo,
                Email = colaborador.Email,
                Telefone = colaborador.Telefone,
                Logradouro = colaborador.Logradouro,
                Numero = colaborador.Numero,
                Bairro = colaborador.Bairro,
                Cidade = colaborador.Cidade,
                UF = colaborador.UF,
                CEP = colaborador.CEP,
                Ativo = colaborador.Ativo
            };
        }

        public bool DeleteColaborador(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            var isDelete = _colaboradorRepository.Deletar(id);

            if (!isDelete)
                throw new KeyNotFoundException($"Colaborador com Id: {id} não encontrada");

            return isDelete;
        }

        public int LoginColaborador(LoginDTO loginDTO)
        {
            var colaborador = _colaboradorRepository.ColaboradorLogin(loginDTO.Email, loginDTO.Senha);

            if (colaborador == null)
                return 0;

            return colaborador.Id;
        }

        public bool ValidaColaboradorEmailExistente(string email)
        {
            var colaborador = _colaboradorRepository.GetColaboradorByEmail(email);
            return colaborador != null;
        }

        public bool ValidaEmpresaEmailExistente(string email)
        {
            var empresa = _empresaRepository.GetEmpresaByEmail(email);
            return empresa != null;
        }
    }
}
