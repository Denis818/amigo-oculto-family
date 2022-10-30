using AmigoOculto.Models.User;

namespace AmigoOculto.Interfaces
{
    public interface ISecretFriend
    {
        Task<string> GenerateSecretFriend();
    }
}