using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebBanSach.Models;
using WebBanSach.Models.Datas;
using WebBanSach.Repository.Interface;

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

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> Index()
        {
            var lst = await _bookRepository.GetAllBooks();

            return View(lst);
        }


        [HttpGet]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> LoadBook()
        {
            var lst = await _bookRepository.GetAllBooks();
            return View(lst);
        }

        [HttpGet]
        public async Task<IActionResult> BookDetails(int masach)
        {
            var lst = await _bookRepository.GetById(masach);
            return View(lst);
        }


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