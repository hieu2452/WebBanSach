using Microsoft.AspNetCore.Mvc;
using WebBanSach.Models;
using WebBanSach.Models.ProductModels;

namespace WebBanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPI : ControllerBase
    {
        DbBookStoreContext db = new DbBookStoreContext();

        public IEnumerable<Product> GetProducts()
        {

            var products = (from p in db.TSaches
                            select new Product
                            {
                                MaSp = p.MaSach,
                                TenSp = p.TenSach,
                                TacGia = p.TacGia,
                                DonGia = p.DonGia,
                                MaTl = p.MaTl,
                                Anh = p.Anh,
                                MoTa = p.Mota,
                                Active = p.InActive
                            }).ToList();
            return products;
        }

        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maloai)
        {

            var products = (from p in db.TSaches
            where p.MaTl.ToString() == maloai
                            select new Product
                            {
                                MaSp = p.MaSach,
                                TenSp = p.TenSach,
                                TacGia = p.TacGia,
                                DonGia = p.DonGia,
                                MaTl = p.MaTl,
                                Anh = p.Anh,
                                MoTa = p.Mota,
                                Active = p.InActive
                            }).ToList();
            return products;
        }
    }
}
