namespace PROJETO.IHC.Domain.Entities
{
    public class Contato : EntityBase
    {
        public Contato() { }

        public Contato(int id, string telefone, string email) : base(id)
        {
            this.Telefone = telefone;
            this.Email = email;
        }

        public string Telefone { get; set; }

        public string Email { get; set; }


        public virtual Colaborador Colaborador { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
