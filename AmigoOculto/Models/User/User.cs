using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AmigoOculto.Models.User
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        [Display(Name = "Quem Selecionou")]
        public string QuemSelecionou { get; set; }

        [Display(Name = "Foi Escolhido")]
        public bool FoiEscolhido { get; set; }
        public int Codigo { get; set; }
        public string Password { get; set; }
    }
}
