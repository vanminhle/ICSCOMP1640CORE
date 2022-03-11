using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Enums;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ICSCOMP1640CORE.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = Role.Coordinator)]
    public class CoordinatorsController : Controller
    {
        private ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CoordinatorsController(ApplicationDbContext db, INotyfService notyf, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _notyf = notyf;
        }

        // Coordinator Profile
        [HttpGet]
        public ActionResult InforCoordinator()
        {
            var userId = _userManager.GetUserId(User);
            var coordinatorInDb = _db.Users.Include(x => x.UserName)
                .SingleOrDefault(t => t.UserName == userId);
            if (coordinatorInDb == null)
            {
                return NotFound();
            }
            return View(coordinatorInDb);
        }

        //Coordinator Manage Idea Category
        [HttpGet]
        public IActionResult ManageCategory(string searchCategory)
        {
            var categoryInDb = _db.Categories.ToList();
            if (!String.IsNullOrEmpty(searchCategory))
            {
                categoryInDb = categoryInDb.FindAll(s => s.Name.Contains(searchCategory));
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
            var check = _db.Categories.Any(c => c.Name.Equals((category.Name).Trim()));
            if (check)
            {
                _notyf.Warning("Category is already exists.", 3);
                return View(category);
            }
            var newCategoryInDb = new Category
            {
                Name = category.Name,
                Description = category.Description,
            };
            _db.Categories.Add(newCategoryInDb);
            _db.SaveChanges();
            _notyf.Success("Category is created successfully.", 3);
            return RedirectToAction("ManageCategory","Coordinators");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var categoryInDb = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryInDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryInDb);
            _db.SaveChanges();
            _notyf.Success("Category is deleted successfully.", 3);
            return RedirectToAction("ManageCategory", "Coordinators");
        }

        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryInDb = _db.Categories.SingleOrDefault(c => c.Id == id);
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
            var categoryInDb = _db.Categories.SingleOrDefault(c => c.Id == category.Id);
            if (categoryInDb == null)
            {
                return NotFound();
            }
            var check = _db.Categories.Any(c => c.Name.Equals(category.Name));
            if (check)
            {
                _notyf.Warning("Category is already exists", 3);
                return View(category);
            }
            categoryInDb.Name = category.Name;
            categoryInDb.Description = category.Description;
            _db.SaveChanges();
            _notyf.Success("Category is edited successfully.", 3);
            return RedirectToAction("ManageCategory", "Coordinators");
        }
    }
}