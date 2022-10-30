using AmigoOculto.DbContext;
using AmigoOculto.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AmigoOculto.Controllers.Login
{
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;


        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        
        {
            return View();
        }

        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResisterUser([FromForm] User user)
        {
            var usuario = new User
            {
                UserName = user.Name,
            };

            var userCreate = await _userManager.CreateAsync(usuario, user.Password);

            if (!userCreate.Succeeded)
            {
                return BadRequest(userCreate.Errors);
            }

            await _signInManager.SignInAsync(usuario, false);

            await CodigoSugestaoPresente(user);

            return RedirectToAction("Login", "Login");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] User user)
        {
            var userLogin = await _signInManager.PasswordSignInAsync(user.Name, user.Password,
                                                                     isPersistent: false, lockoutOnFailure: false);

            if (!userLogin.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login Inválido...");

                return BadRequest(ModelState);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task CodigoSugestaoPresente(User user)
        {
            var sugetsao = new SugestoesPresente
            {
                Name = user.UserName,
                Codigo = user.Codigo
            };

            await _context.SugestoesPresente.AddAsync(sugetsao);
            await _context.SaveChangesAsync();
        }
    }
}
