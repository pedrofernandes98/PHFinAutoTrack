using System.ComponentModel.DataAnnotations;

namespace PHFinAutoTrack.Application.DTOs
{
    public class CategoriaDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} carateres.", MinimumLength = 2)]
        public string Nome { get; set; }

        public IEnumerable<LancamentoDTO> Lancamentos;
    }
}
