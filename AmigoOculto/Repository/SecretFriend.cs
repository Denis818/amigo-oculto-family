using AmigoOculto.DbContext;
using AmigoOculto.Interfaces;
using AmigoOculto.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AmigoOculto.Repository
{
    public class SecretFriend : ISecretFriend
    {
        private readonly AppDbContext _context;
        private readonly HttpContextAccessor _httpContext;

        public SecretFriend(AppDbContext context, HttpContextAccessor httpContext = null)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<string> GenerateSecretFriend()
        {
            Random random = new();

            var listUsers = await _context.User.Where(user => user.FoiEscolhido == false 
            && _httpContext.HttpContext.User.Identity.Name != user.Nome).ToListAsync();

            var userEscolhido =  listUsers[random.Next(listUsers.Count)];

            await UserEscolhido(userEscolhido);

            return userEscolhido.Nome;
        }

        public async Task UserEscolhido(User user)
        {
            user.FoiEscolhido = true;
            user.QuemSelecionou = _httpContext.HttpContext.User.Identity.Name;

            _context.User.Update(user);

            await _context.SaveChangesAsync();
        }

    
    }
}
