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
using System.Threading.Tasks;

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

        // Staff
        [HttpGet]
        public async Task<IActionResult> ManageStaffs(string searchString)
        {

            /*var coordinatorInDb = _db.Users.OfType<User>().Include(x => x.Department)
                .Where(m => m.DepartmentId == currentDepartmentId)
                .ToList();*/


            var currentUser = await _userManager.GetUserAsync(User);
            var currentDepartmentId = currentUser.DepartmentId;
            var dataStaff = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
            var data = dataStaff.Where(x =>x.DepartmentId == currentDepartmentId);
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

            return View(data);
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

        [HttpGet]
        public IActionResult DeleteStaff(string Id)
        {
            var staffindb = _db.Users.SingleOrDefault(item => item.Id == Id);
            if (staffindb == null)
            {
                return NotFound();
            }
            _db.Users.Remove(staffindb);
            _db.SaveChanges();

            _notyf.Success("Staff account is deleted successfully.");
            return RedirectToAction("ManageStaffs");
        }
        [HttpGet]
        public ActionResult InforCoordinator(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            id = userId.ToString();
            var CoordinatorInDb = _db.Users.SingleOrDefault(i => i.Id == id);
            if (CoordinatorInDb == null)
            {
                return NotFound();
            }
            return View(CoordinatorInDb);
        }
        [HttpGet]
        public ActionResult EditProfile(string Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Id = userId.ToString();
            var CoordinatorInDb = _db.Users.SingleOrDefault(i => i.Id == Id);

            var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");
            return View(CoordinatorInDb);
        }

        [HttpPost]
        public ActionResult EditProfile(Coordinator coordinator, string id)
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

            _db.Update(coordinatorinDb);
            _db.SaveChanges();
            _notyf.Success("Coordinator account is edited successfully.");
            return RedirectToAction("InforCoordinator");
        }

    }

}
