using System.ComponentModel.DataAnnotations;

namespace AmigoOculto.Models.User
{
    public class SugestoesPresente
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}
