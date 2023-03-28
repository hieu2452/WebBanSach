using Microsoft.EntityFrameworkCore;
using WebBanSach.Models;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebBanSach.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DbBookStoreContext _context = null;
        private readonly IConfiguration _configuration;

        public BookRepository(DbBookStoreContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        async Task<List<TSach>> IBookRepository.GetAllBooks()
        {
            return await _context.TSaches.ToListAsync();

        }

        async Task<TSach> IBookRepository.GetById(int bookid)
        {
            return await _context.TSaches.FirstOrDefaultAsync(b => b.MaSach == bookid);

        }

        async Task<int> IBookRepository.AddNewBook(BookModel model)
        {
            var book = new TSach()
            {
                TacGia = model.TacGia,
                DonGia = model.DonGia,
                Mota = model.MoTa,
                TenSach = model.TenSach,
                MaNg = model.MaNg,
                MaTl = model.MaTl,
                MaNxb = model.MaNxb,
                Anh = model.Anh,
                SoLuong = model.SoLuong,
                InActive = true,
            };

            await _context.TSaches.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.MaSach;
        }

        async Task<int> IBookRepository.DeleteBook(int id)
        {
            var lstCt = await _context.TChiTietHoaDons.Where(x => x.MaSach == id).ToListAsync();
            if (lstCt.Any())
            {
                return 0;
            }
            var book = await _context.TSaches.FirstOrDefaultAsync(b => b.MaSach == id);
            _context.TSaches.Remove(book);
            await _context.SaveChangesAsync();
            return 1;

        }


        async Task IBookRepository.UpdateBook(TSach book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
