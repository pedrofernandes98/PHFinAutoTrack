using System.ComponentModel.DataAnnotations;

namespace PHFinAutoTrack.Application.DTOs
{
    public class LancamentoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter entre {2} e {1} carateres.", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        public string Imagem { get; set; }

        public Guid CategoriaId { get; set; }

        public CategoriaDTO Categoria { get; set; }
    }
}
