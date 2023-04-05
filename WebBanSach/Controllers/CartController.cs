using Microsoft.AspNetCore.Mvc;
using WebBanSach.Models.Datas;
using WebBanSach.Models;
using System.Text.Json;
using WebBanSach.Repository.Interface;
using Microsoft.AspNetCore.Authorization;

namespace WebBanSach.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public CartController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }


        [Authorize]
        [Authorize(Policy = "UserPolicy")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(TSach sach)
        {
            var book = await _bookRepository.GetById(sach.MaSach);

            string cartJson = HttpContext.Session.GetString("Cart");

            List<CartItem> cartItems = string.IsNullOrEmpty(cartJson) ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(cartJson);

            CartItem cartItem = new CartItem()
            {
                MaSach = book.MaSach,
                TenSach = book.TenSach,
                TacGia = book.TacGia,
                DonGia = book.DonGia,
                SoLuong = sach.SoLuongMua,
                MoTa = book.Mota,
                Anh = book.Anh
            };

            CartItem itemInCart = cartItems.FirstOrDefault(x => x.MaSach == book.MaSach);

            if (itemInCart != null)
            {
                itemInCart.SoLuong += sach.SoLuongMua;
            }
            else
            {
                cartItems.Add(cartItem);
            }
            string updatedCartJson = JsonSerializer.Serialize(cartItems);
            HttpContext.Session.SetString("Cart", updatedCartJson);


            return RedirectToAction("BookDetails", "Home", new { masach = book.MaSach });
        }


        [Authorize]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> RemoveFromCart(int masach)
        {

            string cartJson = HttpContext.Session.GetString("Cart");
            List<CartItem> cartItems = string.IsNullOrEmpty(cartJson)
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(cartJson);

            // CartItem item = cartItems.FirstOrDefault(x => x.MaSach == masach);

            //cartItems.Remove(cartItems.FirstOrDefault(x => x.MaSach == masach));

            int indexToRemove = -1;
            for (int i = 0; i < cartItems.Count(); i++)
            {
                if (cartItems[i].MaSach == masach)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                cartItems.RemoveAt(indexToRemove);
            }
            string updatedCartJson = JsonSerializer.Serialize(cartItems);
            HttpContext.Session.SetString("Cart", updatedCartJson);

            return RedirectToAction("Cart", "Home");
        }

    }
}
