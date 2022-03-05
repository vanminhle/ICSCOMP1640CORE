using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ICSCOMP1640CORE.Controllers
{
    public class AdminsController : Controller
    {
        private ApplicationDbContext _db;

        public AdminsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var departments = _db.Departments.ToList();
            return View(departments);
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existDepartment = _db.Departments.Any(x => x.DepartmentName == model.DepartmentName);
            if (existDepartment == true)
            {
                ModelState.AddModelError("", "Department Already Exists.");
                return View(model);
            }
            var newDepartment = new Department()
            {
                DepartmentName = model.DepartmentName,
                Description = model.Description,
            };
            _db.Departments.Add(newDepartment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
