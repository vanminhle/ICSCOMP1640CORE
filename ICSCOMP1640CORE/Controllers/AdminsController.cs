using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ICSCOMP1640CORE.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class AdminsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private ApplicationDbContext _db;

        public AdminsController(ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult DepartmentIndex()
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
            return RedirectToAction("DepartmentIndex");
        }

        [HttpGet]
        public IActionResult DeleteDepartment(int id)
        {
            var departmentsInDb = _db.Departments.SingleOrDefault(x => x.DepartmentId == id);

            if (departmentsInDb == null)
            {
                return NotFound();
            }

            _db.Departments.Remove(departmentsInDb);
            _db.SaveChanges();

            return RedirectToAction("DepartmentIndex");
        }

        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var departmentInDb = _db.Departments.SingleOrDefault(x => x.DepartmentId == id);
            var department = _db.Departments.ToList();
            var departmentList = _db.Departments.Select(x => new { x.DepartmentId, x.DepartmentName }).ToList();

            ViewBag.departmentList = new SelectList(departmentList, "DepartmentId", "DepartmentName");
            if (departmentInDb == null)
            {
                return NotFound();
            }

            return View(departmentInDb);
        }

        [HttpPost]
        public IActionResult EditDepartment(Department department)

        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            var departmentInDb = _db.Departments.SingleOrDefault(x => x.DepartmentId == department.DepartmentId);

            departmentInDb.DepartmentName = department.DepartmentName;
            departmentInDb.Description = department.Description;
            _db.SaveChanges();

            return RedirectToAction("DepartmentIndex");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCoordinator()
        {
            Coordinator model = new Coordinator();

            var department = _db.Departments.ToList();
            var departmentList = _db.Departments.Select(x => new { x.DepartmentId, x.DepartmentName }).ToList();

            ViewBag.departmentList = new SelectList(departmentList, "DepartmentId", "DepartmentName");
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCoordinator(Coordinator coordinator)
        {
            if (!ModelState.IsValid) return View(coordinator);

            if (_userManager.FindByEmailAsync(coordinator.User.Email).GetAwaiter().GetResult() != null)
            {
                TempData["Danger"] = "The email address is already registered";
                return RedirectToAction("CreateCoordinator");
            }
            var user = coordinator.User;
            user.UserName = user.Email;

            IdentityResult result = _userManager.CreateAsync(user, user.PasswordHash).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Coordinator").GetAwaiter().GetResult();
            }
            var coordinatorProfile = new Coordinator();
            coordinatorProfile.UserId = user.Id;
            coordinatorProfile.DepartmentId = coordinator.DepartmentId;
            _db.Coordinators.Add(coordinatorProfile);
            _db.SaveChanges();
            return RedirectToAction("ManageCoordinator");
        }

        public IActionResult ManageCoordinator()
        {
            var coordinatorInDb = _db.Coordinators.Include(x => x.User).ToList();
            return View(coordinatorInDb);
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var coordinatorindb = _db.Users.SingleOrDefault(item => item.Id == Id);
            _db.Users.Remove(coordinatorindb);
            _db.SaveChanges();

            return RedirectToAction("ManageCoordinator");
        }

        public ActionResult EditCoordinator(string Id)
        {
            var todoInDb = _db.Users
              .SingleOrDefault(item => item.Id == Id);

            return View(todoInDb);
        }

        [HttpPost]
        public ActionResult EditCoordinator(User user)
        {
            var coordinatorinDb = _db.Coordinators.Include(x => x.User)
                .SingleOrDefault(item => item.UserId == user.Id);
            coordinatorinDb.User.FullName = user.FullName;
            coordinatorinDb.User.Address = user.Address;
            coordinatorinDb.User.Age = user.Age;
            coordinatorinDb.User.PhoneNumber = user.PhoneNumber;
            _db.SaveChanges();

            return RedirectToAction("ManageTrainer");
        }
    }
}