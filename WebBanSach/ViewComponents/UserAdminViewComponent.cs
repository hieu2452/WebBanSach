using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text.Json;
using WebBanSach.Models;
using WebBanSach.Models.Datas;

namespace WebBanSach.ViewComponents
{
    public class UserAdminViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string userif = HttpContext.Session.GetString("UserInfo");

            TUser user = new TUser();

            user = JsonSerializer.Deserialize<TUser>(userif);
            return View(user);
        }

    }
}
