using HReport.Data;
using HReport.Models;
using Microsoft.AspNetCore.Mvc;

namespace HReport.Controllers
{
    public class EditAddController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ApplicationDbContext _db;

        public EditAddController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult ToggleCompletion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = _db.InfoReports.Find(id);
            if (complaint == null)
            {
                return NotFound();
            }

            // Odwracanie obecnego stanu IsChecked w bazie danych
            complaint.IsChecked = !complaint.IsChecked;

            // Zapisanie zmian w bazie danych
            _db.SaveChanges();

            return RedirectToAction("Index"); // lub inna akcja, do której chcesz przekierować po zapisaniu zmian
        }



        public IActionResult Index()
        {
            List<InfoReport> entries = _db.InfoReports.ToList();

            return View(entries);
        }


        public IActionResult Func()
        {
            return View();
        }

        public IActionResult AddComplaints()
        {

            return View();
        }

    }
}
