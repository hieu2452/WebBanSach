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
                bool emailExists = await _context.TUsers.AnyAsync(u => u.Email == model.Email);

                if (emailExists)
                {
                    TempData["EmailUsed"] = "Email đã có người sử dụng";
                    return View(model);

                }
                else
                {
                    var user = new TUser { UserN = model.Name, Email = model.Email, PassW = model.Password, RoleId = "User" };
                    TempData["Success"] = "Đăng ký thành công";
                    await _context.TUsers.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login", "Account");
                }


                
/*                else
                {
                    ViewBag.ErrorMessage = "Email exists";
                }*/
            }

            return View(model);
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
                HttpContext.Session.SetString("UserID", user.Id.ToString());
                if(user.AnhDaiDien == null)
                {
                    HttpContext.Session.SetString("UserAnh", "../users/profilepictures/profile.jpg");
                }
                else
                {
                    HttpContext.Session.SetString("UserAnh", user.AnhDaiDien.ToString());
                }
                
                return RedirectToAction("Admin", "Home");
            }
            else
            {
                HttpContext.Session.SetString("UserName", user.UserN.ToString());
                HttpContext.Session.SetString("UserRole", user.RoleId.ToString());
                HttpContext.Session.SetString("UserID", user.Id.ToString());
                if (user.AnhDaiDien == null)
                {
                    HttpContext.Session.SetString("UserAnh", "../users/profilepictures/profile.jpg");
                }
                else
                {
                    HttpContext.Session.SetString("UserAnh", user.AnhDaiDien.ToString());
                }
                return RedirectToAction("Index", "Home");

            }



            return View(model);


        }

        public async Task<IActionResult> Logout()
        {

            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("UserRole");
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserAnh");
            HttpContext.Session.Remove("Cart");

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
