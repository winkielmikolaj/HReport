using HReport.Data;
using HReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult ToggleCompletion(int? id, bool IsCompleted)
        {
            var complaint = _db.InfoReports.Find(id);
            //DO NAPRAWY!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (IsCompleted == true)
            {
                IsCompleted = false;
                complaint.IsChecked = IsCompleted;
                _db.SaveChanges();
            }
            else
            {
                IsCompleted = true;
                complaint.IsChecked = IsCompleted;
                _db.SaveChanges();
            }


            // Przekierowanie z powrotem do listy
            return RedirectToAction("Index");
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
