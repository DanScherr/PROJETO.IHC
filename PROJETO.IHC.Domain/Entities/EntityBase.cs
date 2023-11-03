namespace PROJETO.IHC.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() { }

        protected EntityBase(int id) 
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public bool Ativo { get; set; }

        public void Ativar()
        {
            this.Ativo = true;
        }

        public void Desativar()
        {
            this.Ativo = false;
        }
    }
}
