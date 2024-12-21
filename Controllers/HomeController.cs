using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Smart_Campus_Web_App.Data;
using Smart_Campus_Web_App.Models;
using System.Diagnostics;

namespace Smart_Campus_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Chat() 
        {
            List<MsgHist> hist = new List<MsgHist>();

            foreach (var item in _context.ChatHist)
            {
                Console.WriteLine(item.Msg);
                hist.Add(item);
            }

            ViewData["MyData"] = hist;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Chat(MsgHist model)
        {
           
            var newHist = new MsgHist
            {
                Username = model.Username,
                Msg = model.Msg,
            };

            

            _context.ChatHist.Add(newHist);
            _context.SaveChanges();

            return RedirectToAction("Chat");

        }
    }
}
