using WebBanSach.Models;
using WebBanSach.Models.Datas;

namespace WebBanSach.Repository.Interface
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<TSach>> GetAllBooks();

        Task<TSach> GetById(int bookid);

        Task UpdateBook(TSach book);

        Task<int> DeleteBook(int id);
    }
}
