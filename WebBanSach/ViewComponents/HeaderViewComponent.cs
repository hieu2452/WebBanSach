using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebBanSach.Models;

namespace WebBanSach.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string userif = HttpContext.Session.GetString("UserInfo");

            ViewBag.Userif = userif;    
            return View();
        }
    }
}
