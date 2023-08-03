namespace PHFinAutoTrack.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }

        //EF Releations
        public IEnumerable<Lancamento> Lancamentos;

        //TODO => Criar validações de domínio
    }
}
