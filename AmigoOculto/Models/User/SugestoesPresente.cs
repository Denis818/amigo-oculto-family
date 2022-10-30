using System.ComponentModel.DataAnnotations;

namespace AmigoOculto.Models.User
{
    public class SugestoesPresente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public int Codigo { get; set; }
    }
}
