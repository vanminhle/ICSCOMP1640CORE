using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace ICSCOMP1640CORE.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = Role.Manager)]
    public class ManagersController : Controller
    {
        private ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManagersController(ApplicationDbContext db, INotyfService notyf, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _notyf = notyf;
        }

        //Manage Idea Category
        [HttpGet]
        public IActionResult ManageCategories(string searchCategory, int pg)
        {
            var categoryInDb = _db.Categories.ToList();
            if (!String.IsNullOrEmpty(searchCategory))
            {
                categoryInDb = categoryInDb.FindAll(s => s.Name.Contains(searchCategory));
            }
            //return View(categoryInDb);

            //Pagination
            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int recsCount = categoryInDb.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var pageData = categoryInDb.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(pageData);
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
                Name = category.Name.Trim(),
                Description = category.Description,
            };
            _db.Categories.Add(newCategoryInDb);
            _db.SaveChanges();
            _notyf.Success("Category is created successfully.", 3);
            return RedirectToAction("ManageCategories", "Managers");
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
            return RedirectToAction("ManageCategories", "Managers");
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
            var check = _db.Categories.Any(c => c.Name.Equals((category.Name).Trim()));
            if (check)
            {
                _notyf.Warning("Category is already exists", 3);
                return View(category);
            }
            categoryInDb.Name = category.Name.Trim();
            categoryInDb.Description = category.Description;
            _db.SaveChanges();
            _notyf.Success("Category is edited successfully.", 3);
            return RedirectToAction("ManageCategories", "Managers");
        }
        //Coordinator
        [HttpGet]
        public IActionResult ManageCoordinators(string searchString, int pg = 1)
        {
            //var coordinatorInDb = _db.Users.OfType<User>().Include(x => x.Department).Where(m=> m.).ToList();
            var data = _userManager.GetUsersInRoleAsync("Coordinator").Result.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                data = data
                    .Where(s => s.FullName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();
            }
            foreach (var user in data)
            {
                _db.Entry(user).Reference(x => x.Department).Load();
            }
            //return View(data);

            //Pagination
            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int recsCount = data.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var pageData = data.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(pageData);
        }
        [HttpGet]
        public ActionResult InforCoordinator(string id)
        {
            var info = _db.Users.OfType<User>().Include("Department").FirstOrDefault(t => t.Id == id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        [HttpGet]
        public ActionResult InforStaff(string id)
        {
            var info = _db.Users.OfType<User>().Include("Staff").FirstOrDefault(t => t.Id == id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        [HttpGet]
        public ActionResult InforManager(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            id = userId.ToString();
            var ManagerInDb = _db.Users.SingleOrDefault(i => i.Id == id);
            if (ManagerInDb == null)
            {
                return NotFound();
            }
            return View(ManagerInDb);
        }

        [HttpGet]
        public ActionResult EditProfile(string Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Id = userId.ToString();
            var ManagerInDb = _db.Users.SingleOrDefault(i => i.Id == Id);

            var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");
            return View(ManagerInDb);
        }

        [HttpPost]
        public ActionResult EditProfile(Manager manager, string id)
        {
            var ManagerInDb = _db.Users.OfType<User>().FirstOrDefault(t => t.Id == id);

            if (ManagerInDb == null)
            {
                return BadRequest();
            }

            ManagerInDb.FullName = manager.FullName;
            ManagerInDb.Address = manager.Address;
            ManagerInDb.Age = manager.Age;
            ManagerInDb.Gender = manager.Gender;
            ManagerInDb.DepartmentId = manager.DepartmentId;
            ManagerInDb.PhoneNumber = manager.PhoneNumber;

            _db.Update(ManagerInDb);
            _db.SaveChanges();
            _notyf.Success("Manager account is edited successfully.");
            return RedirectToAction("InforManager");
        }

        [HttpGet]
        public IActionResult ManageIdea()
        {
            var ideaInDb = _db.Ideas.Include(x => x.User).ToList();
            var categoryInDb= _db.Categories.ToList();
            return View(ideaInDb);
        }

        [HttpGet]
        public IActionResult ViewDetailIdea(int Id)
        {
            var ideaInDb = _db.Ideas.Include(x => x.User).SingleOrDefault(item => item.Id == Id);
        /*    var idea = _db.Ideas.Include(x => x.User).FirstOrDefault(item => item.Id == Id);*/
            return View(ideaInDb);
        }
       /* [HttpGet]
        public IActionResult DeleteIdea(int id)
        {
            var IdeasInDb = _db.Ideas.SingleOrDefault(x => x.Id == id);

            if (IdeasInDb == null)
            {
                return NotFound();
            }
            _notyf.Success("Ideas is deleted successfully.");
            _db.Ideas.Remove(IdeasInDb);
            _db.SaveChanges();

            return RedirectToAction("ManageIdea");
        }*/


        [HttpGet]
        public IActionResult DeleteAllIdea()
        {
            var ideaInDb = _db.Ideas;
            if (ideaInDb == null)
            {
                return NotFound();
            }
            _db.Ideas.RemoveRange(ideaInDb);
            _db.SaveChanges();
            _notyf.Success("All Ideals is deleted successfully.", 3);
            return RedirectToAction("ManageIdea", "Managers");
        }
    }
}
