using ABCMoneyTransfer.DTOs;
using ABCMoneyTransfer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ABCMoneyTransfer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            return View(new AuthViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind(Prefix="Register")]UserDTO register)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new AuthViewModel { Register = register, Login = new LoginDTO() });
            }

            var result = await _accountService.RegisterAsync(register);
            if (result.Succeeded)
            {
                TempData["RegistrationSuccess"] = "Registration successful. Please log in.";
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            ViewBag.ShowRegister = true;
            return View("Index", new AuthViewModel { Register = register, Login = new LoginDTO() });
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind(Prefix = "Login")] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _accountService.LoginAsync(dto);
            if (!string.IsNullOrEmpty(token))
            {
                var expiryMinutes = double.Parse(_configuration["Jwt:ExpirationInMinutes"]);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true, 
                    Secure = true,   
                    Expires = DateTime.UtcNow.AddMinutes(expiryMinutes)
                };
                Response.Cookies.Append("jwtToken", token, cookieOptions);
                return RedirectToAction("Dashboard", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid Credentials ");
            return View("Index", new AuthViewModel { Login = dto, Register = new UserDTO() });
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwtToken");
            return RedirectToAction("Index");
        }

    }
}
