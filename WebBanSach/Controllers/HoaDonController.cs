using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Models.Datas;
using WebBanSach.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace WebBanSach.Controllers
{
    public class HoaDonController : Controller
    {

        private readonly DbBookStoreContext _context;

        public HoaDonController(DbBookStoreContext context)
        {
            _context = context;
        }

        [Authorize]
        [Authorize(Policy = "UserPolicy")]
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


        [Authorize]
        [Authorize(Policy = "UserPolicy")]
        public IActionResult HoaDonMuaHang()
        {
            string userif = HttpContext.Session.GetString("UserInfo");

            TUser user = new TUser();

            user = JsonSerializer.Deserialize<TUser>(userif);

            var bills = from h in _context.THoaDons
                        join u in _context.TUsers on h.Id equals u.Id
                        join c in _context.TChiTietHoaDons on h.MaHd equals c.MaHd
                        join s in _context.TSaches on c.MaSach equals s.MaSach
                        where u.Id == user.Id
                        group new { h, u, c, s } by new { h.MaHd, h.Id } into g
                        select new HoaDonModel
                        {
                            MaHD = g.Key.MaHd,
                            UserN = g.First().u.UserN,
                            ngaytao = (DateTime)g.First().h.NgayTao,
                            SDT = g.First().u.Sdt,
                            bookDetail = g.Select(x => new BookDetailModel
                            {
                                TenSach = x.s.TenSach,
                                SoLuong = (int)x.c.SoLuong,
                                DonGia = (int)x.s.DonGia
                            }).ToList(),
                            tongTien = (double)g.Sum(x => x.s.DonGia * x.c.SoLuong)
                        };

            bills = bills.OrderByDescending(b => b.ngaytao);

            return View(bills);
        }

    }
}
