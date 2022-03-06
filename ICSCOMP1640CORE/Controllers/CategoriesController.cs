using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ICSCOMP1640CORE.Controllers
{
    [Authorize(Roles = Role.Coordinator)]

    public class CategoriesController : Controller
    {
        public ApplicationDbContext _db;
        private readonly INotyfService _notfy;

        public CategoriesController(ApplicationDbContext db, INotyfService notfy)
        {
            _db = db;
            _notfy = notfy;
        }
        public IActionResult Index(string searchCategory)
        {
            var categoryInDb = _db.Categories.ToList();
            if (!String.IsNullOrEmpty(searchCategory))
            {
                categoryInDb = categoryInDb.FindAll(s => s.CategoryName.Contains(searchCategory));
            }
            return View(categoryInDb);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCategory");
            }
            var check = _db.Categories.Any(
                c => c.CategoryName.Equals(category.CategoryName));
            if (check)
            {
                _notfy.Error("Name Of Category Is Already Exist", 3);
                return View("CreateCategory");

            }
            var newCategoryInDb = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
            };
            _db.Categories.Add(newCategoryInDb);
            _db.SaveChanges();
            _notfy.Success("Category Added Successfully!", 3);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var categoryInDb = _db.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (categoryInDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryInDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryInDb = _db.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (categoryInDb == null)
            {
                return NotFound();
            }
            return View(categoryInDb);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var categoryInDb = _db.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            if (categoryInDb == null)
            {
                return NotFound();
            }
            var check = _db.Categories.Any(c => c.CategoryName.Equals(category.CategoryName));
            if (check)
            {
                _notfy.Error("Name Of Category Is Already Exist", 3);
                return View("EditCategory");
            }
            categoryInDb.CategoryName = category.CategoryName;
            categoryInDb.Description = category.Description;
            _db.SaveChanges();
            _notfy.Success("Edit Category Successfully!", 3);
            return RedirectToAction("Index");
        }
    }
}
