using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ICSCOMP1640CORE.Controllers
{
    [Authorize(Roles = Role.Admin)]
    public class AdminsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly INotyfService _notyf;
        private readonly IEmailSender _emailSender;

        private ApplicationDbContext _db;

        public AdminsController(ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, INotyfService notyf, IEmailSender emailSender)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _notyf = notyf;
            _emailSender = emailSender;
        }
        //Department
        public IActionResult DepartmentsIndex(string searchString, int pg = 1)
        {
            var departments = _db.Departments.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments
                    .Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();
            }

            //Pagination
            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int recsCount = departments.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = departments.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
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

            var existDepartment = _db.Departments.Any(x => x.Name == model.Name.Trim());
            if (existDepartment == true)
            {
                /*ModelState.AddModelError("", "Department Already Exists.");*/
                _notyf.Warning("Department is already exists.");
                return View(model);
            }
            var newDepartment = new Department()
            {
                Name = model.Name.Trim(),
                Description = model.Description,
            };
            _notyf.Success("Department is created successfully.");
            _db.Departments.Add(newDepartment);
            _db.SaveChanges();
            return RedirectToAction("DepartmentsIndex");
        }

        [HttpGet]
        public IActionResult DeleteDepartment(int id)
        {
            var departmentsInDb = _db.Departments.SingleOrDefault(x => x.Id == id);

            if (departmentsInDb == null)
            {
                return NotFound();
            }
            _notyf.Success("Department is deleted successfully.");
            _db.Departments.Remove(departmentsInDb);
            _db.SaveChanges();

            return RedirectToAction("DepartmentsIndex");
        }

        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var departmentInDb = _db.Departments.SingleOrDefault(x => x.Id == id);

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
            var departmentInDb = _db.Departments.SingleOrDefault(x => x.Id == department.Id);
            var existDepartment = _db.Departments.Any(x => x.Name == department.Name.Trim());

            if (existDepartment == true)
            {
                _notyf.Warning("Department is already exists.");
                return View(department);
            }
            _notyf.Success("Department is edited successfully.");
            departmentInDb.Name = department.Name.Trim();
            departmentInDb.Description = department.Description;
            _db.SaveChanges();

            return RedirectToAction("DepartmentsIndex");
        }

        //Coordinator

        [HttpGet]
        public IActionResult CreateCoordinator()
        {
            Coordinator model = new Coordinator();

            var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            var department = _db.Departments.ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoordinator(Coordinator coordinator)
        {
            if (_userManager.FindByEmailAsync(coordinator.Email).GetAwaiter().GetResult() != null)
            {
                //TempData["Danger"] = "The email address is already registered";
                _notyf.Error("This email address is already registered! Please try again!");

                return RedirectToAction("CreateCoordinator");
            }

            if (!ModelState.IsValid) return View(coordinator);

            /*var user = coordinator;
            user.UserName = user.Email;*/

            /*coordinatorProfile = new Coordinator();
            //coordinatorProfile.Id = coordinator.Id;
            coordinatorProfile.Id = user.Id;
            coordinatorProfile.FullName = user.FullName;
            coordinatorProfile.Gender = user.Gender;
            coordinatorProfile.Age = user.Age;
            coordinatorProfile.Address = user.Address;
            coordinatorProfile.PhoneNumber = user.PhoneNumber;*/

            var user = coordinator;
            user.UserName = user.Email;
            IdentityResult result = _userManager.CreateAsync(coordinator, coordinator.PasswordHash).GetAwaiter().GetResult();
            //_db.Users.Add(coordinatorProfile);

            _db.SaveChanges();

            if (result.Succeeded)
            {

                _userManager.AddToRoleAsync(coordinator, "Coordinator").GetAwaiter().GetResult();

                var userId = await _userManager.GetUserIdAsync(coordinator);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(coordinator);

                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    new { area = "Identity", userId = user.Id, code = code },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(
                    coordinator.Email,
                    "Confirm your email",
                    $"Hi, {coordinator.FullName} Please confirm your email account {coordinator.Email} by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            }
            _notyf.Success("Coordinator account is created successfully.");
            return RedirectToAction("ManageCoordinators");
        }

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
        public IActionResult DeleteCondinator(string Id)
        {
            var coordinatorindb = _db.Users.SingleOrDefault(item => item.Id == Id);
            _db.Users.Remove(coordinatorindb);
            _db.SaveChanges();

            _notyf.Success("Coordinator account is deleted successfully.");
            return RedirectToAction("ManageCoordinators");
        }

        [HttpGet]
        public ActionResult EditCoordinator(string Id)
        {
            var coordinatorindb = _db.Users.SingleOrDefault(item => item.Id == Id);
            var user = _db.Users.ToList();

            var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");

            return View(coordinatorindb);
        }

        [HttpPost]
        public ActionResult EditCoordinator(string id, Coordinator coordinator)
        {
            var coordinatorinDb = _db.Users.OfType<User>().FirstOrDefault(t => t.Id == id);

            if (coordinatorinDb == null)
            {
                return BadRequest();
            }

            coordinatorinDb.FullName = coordinator.FullName;
            coordinatorinDb.Address = coordinator.Address;
            coordinatorinDb.Age = coordinator.Age;
            coordinatorinDb.Gender = coordinator.Gender;
            coordinatorinDb.DepartmentId = coordinator.DepartmentId;
            coordinatorinDb.PhoneNumber = coordinator.PhoneNumber;

            /*coordinatorinDb.DepartmentId = coordinator.DepartmentId;*/

            _db.Update(coordinatorinDb);
            _db.SaveChanges();

            _notyf.Success("Coordinator account is edited successfully.");
            return RedirectToAction("ManageCoordinators");
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

        //Manager
        [HttpGet]
        public IActionResult CreateManager()
        {
            Manager model = new Manager();

            /*var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            var department = _db.Departments.ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");*/

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManager(Manager manager)
        {
            if (_userManager.FindByEmailAsync(manager.Email).GetAwaiter().GetResult() != null)
            {
                //TempData["Danger"] = "The email address is already registered";
                _notyf.Error("This email address is already registered! Please try again!");

                return RedirectToAction("CreateManager");
            }

            if (!ModelState.IsValid) return View(manager);

            var user = manager;
            user.UserName = user.Email;
            manager.DepartmentId = 1;
            IdentityResult result = _userManager.CreateAsync(manager, manager.PasswordHash).GetAwaiter().GetResult();

            _db.SaveChanges();

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(manager, "Manager").GetAwaiter().GetResult();

                var userId = await _userManager.GetUserIdAsync(manager);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(manager);

                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new{ area = "Identity", userId = user.Id, code = code },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(
                    manager.Email,
                    "Confirm your email",
                    $"Hi, {manager.FullName} Please confirm your email account {manager.Email} by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            }
            _notyf.Success("Manager account is created successfully.");
            return RedirectToAction("ManageManagers");
        }
        [HttpGet]
        public IActionResult ManageManagers(string searchString, int pg = 1)
        {
            //var coordinatorInDb = _db.Users.OfType<User>().Include(x => x.Department).Where(m=> m.).ToList();
            var data = _userManager.GetUsersInRoleAsync("Manager").Result.ToList();
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
        public IActionResult DeleteManager(string Id)
        {
            var managerindb = _db.Users.SingleOrDefault(item => item.Id == Id);
            _db.Users.Remove(managerindb);
            _db.SaveChanges();

            _notyf.Success("Coordinator account is deleted successfully.");
            return RedirectToAction("ManageManagers");
        }

        [HttpGet]
        public ActionResult EditManager(string Id)
        {
            var managerindb = _db.Users.SingleOrDefault(item => item.Id == Id);
            var user = _db.Users.ToList();

            /*var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");*/

            return View(managerindb);
        }

        [HttpPost]
        public ActionResult EditManager(string id, Manager manager)
        {
            var managerindb = _db.Users.OfType<User>().FirstOrDefault(t => t.Id == id);

            if (managerindb == null)
            {
                return BadRequest();
            }

            managerindb.FullName = manager.FullName;
            managerindb.Address = manager.Address;
            managerindb.Age = manager.Age;
            managerindb.Gender = manager.Gender;
            managerindb.PhoneNumber = manager.PhoneNumber;

            _db.Update(managerindb);
            _db.SaveChanges();

            _notyf.Success("Manager account is edited successfully.");
            return RedirectToAction("ManageManagers");
        }

        [HttpGet]
        public ActionResult InforManager(string id)
        {
            var info = _db.Users.OfType<User>().FirstOrDefault(t => t.Id == id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        //Staff
        [HttpGet]
        public IActionResult ManageStaffs(string searchString, int pg = 1)
        {
            //var coordinatorInDb = _db.Users.OfType<User>().Include(x => x.Department).Where(m=> m.).ToList();
            var data = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
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
        public ActionResult InforStaff(string id)
        {
            var info = _db.Users.OfType<User>().Include("Department").FirstOrDefault(t => t.Id == id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        //Idea
        [HttpGet]
        public IActionResult ManageIdeas()
        {
            var ideaInDb = _db.Ideas.Include(x => x.User).ToList();
            var categoryInDb = _db.Categories.ToList();
            return View(ideaInDb);
        }

        [HttpGet]
        public IActionResult DetailIdea(int Id)
        {
            var idea = _db.Ideas.Include(x => x.User).SingleOrDefault(item => item.Id == Id);
            return View(idea);
        }
    }
}
