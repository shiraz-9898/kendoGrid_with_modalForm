using kendoGridRev.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kendoGridRev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmpDbContext _context;
        public HomeController(ILogger<HomeController> logger, EmpDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show()
        {
            var data = _context.Employees.ToList();
            return Json(data);
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                return Json(emp);
            }
            return Json(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
                return Json(emp);
            }
            return Json(emp);
        }

        [HttpPost]
        public IActionResult Delete(int userId)
        {
            var data = _context.Employees.Find(userId);
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return Json("done");
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
