using AmigoOculto.Interfaces;
using AmigoOculto.Models;
using AmigoOculto.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AmigoOculto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISecretFriend _secretFriend;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ISecretFriend secretFriend, UserManager<User> userManager = null)
        {
            _logger = logger;
            _secretFriend = secretFriend;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
           /* var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);*/
            return View();
        }

        public async Task<IActionResult> GerarNome()
        {
            return View(await _secretFriend.GenerateSecretFriend(););
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}