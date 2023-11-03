using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.IHC.Domain.Entities
{
    public class Projeto : EntityBase
    {
        public Projeto() { }

        public Projeto(int id, string nomeProjeto, string descricaoProjeto, Endereco endereco) : base(id)
        {
            this.NomeProjeto = nomeProjeto;
            this.DescricaoProjeto = descricaoProjeto;
            this.Endereco = endereco;
        }

        public string NomeProjeto { get; set; }

        public string DescricaoProjeto { get; set; }

        public Endereco Endereco { get; set; }
    }
}
