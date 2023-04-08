using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebBanSach.Models;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;
using X.PagedList;

namespace WebBanSach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbBookStoreContext _context;
        private readonly IBookRepository _bookRepository;
        public HomeController(ILogger<HomeController> logger, DbBookStoreContext context, IBookRepository bookRepository)
        {
            _context = context;
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Admin(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var lst = await _bookRepository.GetAllBooks();
            PagedList<TSach> lstbooks = new PagedList<TSach>(lst, pageNumber, pageSize);
            return View(lstbooks);
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var lst = await _bookRepository.GetAllBooks();
            PagedList<TSach> lstbooks = new PagedList<TSach>(lst, pageNumber, pageSize);

            return View(lstbooks);
        }


        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> LoadBook(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var lst = await _bookRepository.GetAllBooks();
            PagedList<TSach> lstbooks = new PagedList<TSach>(lst, pageNumber, pageSize);
            return View(lstbooks);
        }

        [HttpGet]
        public async Task<IActionResult> BookDetails(int masach)
        {
            var lst = await _bookRepository.GetById(masach);
            return View(lst);
        }

        [Authorize]
        [Authorize(Policy = "UserPolicy")]
        public IActionResult Cart()
        {
            string cartJson = HttpContext.Session.GetString("Cart");
            List<CartItem> cartItems = string.IsNullOrEmpty(cartJson)
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(cartJson);

            return View(cartItems);
        }

        

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}