using System.ComponentModel.DataAnnotations;

namespace AmigoOculto.Models.User
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Numero da Sugestao")]
        public int SugestaoId { get; set; }

        [Required]
        [Display(Name = "Quem Selecionou")]
        public string  QuemSelecionou { get; set; }
    }
}
