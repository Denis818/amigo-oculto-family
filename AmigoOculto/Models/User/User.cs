namespace AmigoOculto.Models.User
{
    public class User
    {
        public int NomeId { get; set; }
        public string Nome { get; set; }
        public int SugestaoId { get; set; }
        public string Senha { get; set; }
        public string  QuemSelecionou { get; set; }
    }
}
