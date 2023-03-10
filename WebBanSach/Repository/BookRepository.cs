using WebBanSach.Models;
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
        async Task<int> IBookRepository.AddNewBook(BookModel model)
        {
            var book = new TSach()
            {
                TacGia = model.TacGia,
                DonGia = model.DonGia,
                Mota = model.MoTa,
                TenSach = model.TenSach,
                MaNg = model.MaNg,
                Anh = model.Anh,
                SoLuong = model.SoLuong,
            };

            await _context.TSaches.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.MaSach;
        }

        Task<BookModel> IBookRepository.DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<BookModel>> IBookRepository.GetAllBooks()
        {
            throw new NotImplementedException();
        }

        Task<BookModel> IBookRepository.GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
