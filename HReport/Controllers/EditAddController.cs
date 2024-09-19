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
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string title)
        {
            var results = _db.InfoReports.Where(a => a.Complaint.Contains(title)).ToList();

            return View(results);
        }
     


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            InfoReport? entry = _db.InfoReports.Find(id);

            return View(_db.InfoReports.Find(id));
        }


        [HttpPost]
        public IActionResult Edit(InfoReport obj)
        {

            if (ModelState.IsValid)
            {

                obj.Date = DateTime.UtcNow;

                _db.InfoReports.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);


        }

        public IActionResult Delete(int? id)
        {
            InfoReport entry = _db.InfoReports.Find(id);
            _db.InfoReports.Remove(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddComplaints()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComplaints(InfoReport entry)
        {

            entry.Date = DateTime.UtcNow;

            _db.InfoReports.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");


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

    }
}
