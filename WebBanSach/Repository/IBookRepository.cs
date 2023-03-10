using WebBanSach.Models;

namespace WebBanSach.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        
        Task<BookModel> DeleteBook(int id);
    }
}
