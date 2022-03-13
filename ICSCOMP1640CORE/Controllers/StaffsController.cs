using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICSCOMP1640CORE.Controllers
{
    public class StaffsController : Controller
    {
        private ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public StaffsController(ApplicationDbContext db, INotyfService notyf, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult InforStaff(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            id = userId.ToString();
            var StaffInDb = _db.Users.SingleOrDefault(i => i.Id == id);
            if (StaffInDb == null)
            {
                return NotFound();
            }
            return View(StaffInDb);
        }
        [HttpGet]
        public ActionResult EditProfile(string Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Id = userId.ToString();
            var StaffInDb = _db.Users.SingleOrDefault(i => i.Id == Id);

            var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");
            return View(StaffInDb);
        }

        [HttpPost]
        public ActionResult EditProfile(Staff staff, string id)
        {
            var StaffInDb = _db.Users.OfType<User>().FirstOrDefault(t => t.Id == id);

            if (StaffInDb == null)
            {
                return BadRequest();
            }

            StaffInDb.FullName = staff.FullName;
            StaffInDb.Address = staff.Address;
            StaffInDb.Age = staff.Age;
            StaffInDb.Gender = staff.Gender;
            StaffInDb.DepartmentId = staff.DepartmentId;
            StaffInDb.PhoneNumber = staff.PhoneNumber;

            _db.Update(StaffInDb);
            _db.SaveChanges();
            _notyf.Success("Manager account is edited successfully.");
            return RedirectToAction("InforStaff");
        }
    }
}