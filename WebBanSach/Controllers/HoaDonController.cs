using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Models.Datas;
using WebBanSach.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using WebBanSach.Repository.Interface;
using X.PagedList;

namespace WebBanSach.Controllers
{
    public class HoaDonController : Controller
    {

        private readonly DbBookStoreContext _context;
        private readonly IBookRepository _bookRepository;
        public HoaDonController(DbBookStoreContext context, IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }

        [Authorize]
        [Authorize(Policy = "UserPolicy")]
        [HttpPost]
        public async Task<IActionResult> ThemHoaDon([FromForm] List<CartItem> cartItems)
        {

            /* int userid = Int32.Parse(HttpContext.Session.GetString("UserID"));*/
            /*string cartJson = HttpContext.Session.GetString("Cart");
            List<CartItem> cartItems1 = JsonSerializer.Deserialize<List<CartItem>>(cartJson);*/


            string userif = HttpContext.Session.GetString("UserInfo");

            TUser user = new TUser();

            user = JsonSerializer.Deserialize<TUser>(userif);

            THoaDon hoadon = new THoaDon()
            {
                NgayTao = DateTime.Now,
                Id = user.Id,
            };

            _context.THoaDons.Add(hoadon);
            _context.SaveChanges();

            if (cartItems != null)
            {
                foreach (var cartItem in cartItems)
                {
                    var chiTietHoaDon = new TChiTietHoaDon
                    {
                        MaHd = hoadon.MaHd,
                        MaSach = cartItem.MaSach,
                        SoLuong = cartItem.SoLuong,
                    };
                    var book = await _bookRepository.GetById(cartItem.MaSach);

                    book.SoLuong = cartItem.SoLuong - book.SoLuong;

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
        public IActionResult HoaDonMuaHang(int? page)
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

            int pageSize = 4;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            PagedList<HoaDonModel> lstHoaDon = new PagedList<HoaDonModel>(bills, pageNumber, pageSize);

            return View(lstHoaDon);
        }


        [Authorize]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult HoaDonMuaHangAdmin(int? page)
        {
            var bills = from h in _context.THoaDons
                        join u in _context.TUsers on h.Id equals u.Id
                        join c in _context.TChiTietHoaDons on h.MaHd equals c.MaHd
                        join s in _context.TSaches on c.MaSach equals s.MaSach
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

            int pageSize = 4;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            PagedList<HoaDonModel> lstHoaDon = new PagedList<HoaDonModel>(bills, pageNumber, pageSize);

            return View(lstHoaDon);
        }

        [HttpGet]
        public async Task<IActionResult> TimHoaDonTheoMaHD(string mahd)
        {
            TempData["msg"] = "";
            int hd = int.Parse(mahd);
            var bills = from h in _context.THoaDons
                        join u in _context.TUsers on h.Id equals u.Id
                        join c in _context.TChiTietHoaDons on h.MaHd equals c.MaHd
                        join s in _context.TSaches on c.MaSach equals s.MaSach
                        where h.MaHd == hd
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
            if (bills.Any())
            {

                return View(bills);
            }
            else
            {
                TempData["msg"] = "Không tìm thấy hóa đơn";
                return RedirectToAction("HoaDonMuaHangAdmin");
            }

        }


        [HttpGet]
        public async Task<IActionResult> TimHoaDonTheoMaHDkh(string mahd)
        {
            TempData["msg"] = "";
            int hd = int.Parse(mahd);
            var bills = from h in _context.THoaDons
                        join u in _context.TUsers on h.Id equals u.Id
                        join c in _context.TChiTietHoaDons on h.MaHd equals c.MaHd
                        join s in _context.TSaches on c.MaSach equals s.MaSach
                        where h.MaHd == hd
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
            if (bills.Any())
            {

                return View(bills);
            }
            else
            {
                TempData["msg"] = "Không tìm thấy hóa đơn";
                return RedirectToAction("HoaDonMuaHang");
            }

        }

    }
}
