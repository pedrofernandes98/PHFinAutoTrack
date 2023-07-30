namespace PHFinAutoTrack.Domain.Entities
{
    public class Lancamento : EntityBase
    {
        public DateTime DataLancamento { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public string Imagem { get; set; }

        public Guid CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
