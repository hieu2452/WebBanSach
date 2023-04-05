using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text.Json;
using WebBanSach.Models.Datas;

namespace WebBanSach.ViewComponents
{
    public class CartDetailViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string cartJson = HttpContext.Session.GetString("Cart");

            List<CartItem> cartItems = string.IsNullOrEmpty(cartJson) ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(cartJson);
            return View(cartItems);
        }

    }
}
