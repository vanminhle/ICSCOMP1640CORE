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

namespace ICSCOMP1640CORE.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class AdminsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly INotyfService _notyf;

        private ApplicationDbContext _db;

        public AdminsController(ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, INotyfService notyf)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _notyf = notyf;
        }

        public IActionResult DepartmentIndex(string searchString)
        {
            var departments = _db.Departments.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments
                    .Where(s => s.DepartmentName.ToLower().Contains(searchString.ToLower()))
                .ToList();
            }
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
                /*ModelState.AddModelError("", "Department Already Exists.");*/
                _notyf.Warning("Department Already Exists.");
                return View(model);
            }
            var newDepartment = new Department()
            {
                DepartmentName = model.DepartmentName,
                Description = model.Description,
            };
            _notyf.Success("Department is created successfully.");
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
            _notyf.Success("Department is deleted successfully.");
            _db.Departments.Remove(departmentsInDb);
            _db.SaveChanges();

            return RedirectToAction("DepartmentIndex");
        }

        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var departmentInDb = _db.Departments.SingleOrDefault(x => x.DepartmentId == id);

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
            var existDepartment = _db.Departments.Any(x => x.DepartmentName == department.DepartmentName);

            if (existDepartment == true)
            {
                _notyf.Warning("Department Already Exists.");
                return View(department);
            }
            _notyf.Success("Department is edit successfully.");
            departmentInDb.DepartmentName = department.DepartmentName;
            departmentInDb.Description = department.Description;
            _db.SaveChanges();

            return RedirectToAction("DepartmentIndex");
        }

        //Coordinator

        [HttpGet]
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

            if (_userManager.FindByEmailAsync(coordinator.User.Email).GetAwaiter().GetResult() != null)
            {
                TempData["Danger"] = "The email address is already registered";
                return RedirectToAction("CreateCoordinator");
            }

            if (!ModelState.IsValid) return View(coordinator);

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

        [HttpGet]
        public IActionResult ManageCoordinator()
        {
            var coordinatorInDb = _db.Coordinators.Include(x => x.User).Include(y => y.Department).ToList();

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

        [HttpGet]
        public ActionResult EditCoordinator(string Id)
        {
            var coordinatorindb = _db.Coordinators.SingleOrDefault(item => item.UserId == Id);

            var user = _db.Users.ToList();

            var departmentList = _db.Departments.Select(x => new { x.DepartmentId, x.DepartmentName }).ToList();
            ViewBag.departmentList = new SelectList(departmentList, "DepartmentId", "DepartmentName");

            return View(coordinatorindb);
        }

        [HttpPost]
        public ActionResult EditCoordinator(Coordinator coordinator)
        {
            var coordinatorinDb = _db.Coordinators.Include(x => x.User)
                .SingleOrDefault(item => item.UserId == coordinator.UserId);

            coordinatorinDb.User.FullName = coordinator.User.FullName;
            coordinatorinDb.User.Address = coordinator.User.Address;
            coordinatorinDb.User.Age = coordinator.User.Age;
            coordinatorinDb.User.PhoneNumber = coordinator.User.PhoneNumber;

            coordinatorinDb.DepartmentId = coordinator.DepartmentId;

            _db.SaveChanges();

            return RedirectToAction("ManageCoordinator");
        }

        [HttpGet]
        public ActionResult InforCoordinator(string Id)
        {

            var userId = _userManager.GetUserId(User);
            var coordinatorInDb = _db.Coordinators.Include(x => x.User).Include(y => y.Department).SingleOrDefault(item => item.UserId == Id);
            if (coordinatorInDb == null)
            {
                return NotFound();
            }
            return View(coordinatorInDb);


        }
    }
}
