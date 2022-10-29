using AmigoOculto.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AmigoOculto.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> ResisterUser([FromBody] UserDto userDto)
        {
            var user = new IdentityUser
            {
                UserName = userDto.Name,
            };

            var userCreate = await _userManager.CreateAsync(user, userDto.Password);

            if (!userCreate.Succeeded)
            {
                return BadRequest(userCreate.Errors);
            }

            await _signInManager.SignInAsync(user, false);

            return Ok("Registrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var userLogin = await _signInManager.PasswordSignInAsync(userDto.Name, userDto.Password,
                                                                     isPersistent: false, lockoutOnFailure: false);

            if (!userLogin.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login Inválido...");

                return BadRequest(ModelState);
            }

            return Ok("Logado com sucesso!");
        }

    }
}
