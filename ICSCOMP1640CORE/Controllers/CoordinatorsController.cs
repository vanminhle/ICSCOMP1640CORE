using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> ManageStaffsAsync(string searchString)
        {
            //var coordinatorInDb = _db.Users.OfType<User>().Include(x => x.Department).Where(m=> m.).ToList();
            var currentUser = await _userManager.GetUserAsync(User);
            var currentDepartmentId = currentUser.DepartmentId;
            var dataStaff = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
            var data = dataStaff.Where(x =>x.DepartmentId == currentDepartmentId);
            if (!String.IsNullOrEmpty(searchString))
            {
                data = data
                    .Where(s => s.FullName.ToLower().Contains(searchString.ToLower()))
                .ToList();
            }
            foreach (var user in data)
            {
                _db.Entry(user).Reference(x => x.Department).Load();
            }

            return View(data);
        }
        [HttpGet]
        public ActionResult InforStaff()
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

        [HttpGet]
        public IActionResult DeleteStaff(string Id)
        {
            var staffindb = _db.Users.SingleOrDefault(item => item.Id == Id);
            _db.Users.Remove(staffindb);
            _db.SaveChanges();

            _notyf.Success("Staff account is deleted successfully.");
            return RedirectToAction("ManageStaffsAsync");
        }

    }
}