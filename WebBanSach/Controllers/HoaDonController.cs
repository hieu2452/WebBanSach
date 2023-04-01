using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Models.Datas;
using WebBanSach.Models;
using System.Text.Json;

namespace WebBanSach.Controllers
{
    public class HoaDonController : Controller
    {

        private readonly DbBookStoreContext _context;

        public HoaDonController(DbBookStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ThemHoaDon([FromForm]List<CartItem> cartItems)
        {

            /* int userid = Int32.Parse(HttpContext.Session.GetString("UserID"));*/
            /*string cartJson = HttpContext.Session.GetString("Cart");
            List<CartItem> cartItems1 = JsonSerializer.Deserialize<List<CartItem>>(cartJson);*/


            string userif =  HttpContext.Session.GetString("UserInfo");

            TUser user = new TUser();

            user = JsonSerializer.Deserialize<TUser>(userif);

            THoaDon hoadon = new THoaDon()
            {
                NgayTao = DateTime.Now,
                Id = user.Id,
            };

            _context.THoaDons.Add(hoadon);
            _context.SaveChanges();
            
            if(cartItems != null)
            {
                foreach (var cartItem in cartItems)
                {
                    var chiTietHoaDon = new TChiTietHoaDon
                    {
                        MaHd = hoadon.MaHd,
                        MaSach = cartItem.MaSach,
                        SoLuong = cartItem.SoLuong,
                    };

                    _context.TChiTietHoaDons.Add(chiTietHoaDon);

                    _context.SaveChanges();
                }
            }
            else
            {
                return NotFound();
            }



            //return RedirectToAction("BookDetails", "Home", new { masach = book.MaSach });
            return RedirectToAction("Index", "Home");
        }




    }
}
