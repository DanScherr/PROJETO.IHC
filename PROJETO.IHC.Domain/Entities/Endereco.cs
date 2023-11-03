using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.IHC.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public Endereco() { }

        public Endereco(int id, string logradouro, string numero, string bairro, string cidade, string uf, string cep) : base(id)
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.UF = uf;
            this.CEP = cep;
        }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }
    }
}
