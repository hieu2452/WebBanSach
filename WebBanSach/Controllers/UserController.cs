using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            string userif = HttpContext.Session.GetString("UserInfo");

            TUser user = new TUser();

            user = JsonSerializer.Deserialize<TUser>(userif);


            return View(user);
        }
    }
}
