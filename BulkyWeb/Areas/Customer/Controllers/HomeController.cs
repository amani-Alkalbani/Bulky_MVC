using System.Diagnostics;
using BulkyBook.Models;
using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
            

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList=_unitOfWork.Product.GetAll(includeProperties:"Category");
            return View(productList);
        }


        public IActionResult Details(int productId)
        {

           
            Product produc= _unitOfWork.Product.Get(u=>u.Id== productId, includeProperties: "Category");
            return View(produc);
        }


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
