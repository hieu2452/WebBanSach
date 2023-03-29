using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebBanSach.Models;
using Microsoft.AspNetCore.Identity;
using WebBanSach.Models.Datas;

namespace WebBanSach.Controllers
{
    public class AccountController : Controller
    {

        private readonly DbBookStoreContext _context;

        public AccountController(DbBookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                List<TUser> users = _context.TUsers.Where(x => x.Email == model.Email).ToList();

                if (users == null)
                {
                    var user = new TUser { UserN = model.Name, Email = model.Email, PassW = model.Password, RoleId = "User" };
                    await _context.TUsers.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email exists";
                }
            }

            return View();
        }




        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _context.TUsers.FirstOrDefaultAsync(u => u.Email == model.Email && u.PassW == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleId)
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            if (user.RoleId == "Admin")
            {
                HttpContext.Session.SetString("UserName", user.UserN.ToString());
                HttpContext.Session.SetString("UserRole", user.RoleId.ToString());
                return RedirectToAction("Admin", "Home");
            }
            else
            {
                HttpContext.Session.SetString("UserName", user.UserN.ToString());
                HttpContext.Session.SetString("UserRole", user.RoleId.ToString());
                return RedirectToAction("Index", "Home");

            }

            return View(model);


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
    }
}
