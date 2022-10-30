using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AmigoOculto.Models.User
{
    public class User : IdentityUser
    {
        //[Key]
        //public new int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Numero da Sugestao")]
        public int SugestaoId { get; set; }

        [Display(Name = "Quem Selecionou")]
        public string QuemSelecionou { get; set; }

        [Display(Name = "Foi Escolhido")]
        public bool FoiEscolhido { get; set; }
        public int Codigo { get; set; }
    }
}
