using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICSCOMP1640CORE.Controllers
{
    
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCoordinator()
        {
            Coordinator model = new Coordinator();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateCoordinator(Coordinator coordinator)
        {
            if (!ModelState.IsValid) return View(coordinator);

            if (_userManager.FindByEmailAsync(coordinator.User.Email).GetAwaiter().GetResult() != null)
            {
                TempData["Danger"] = "The email address is already registered";
                return View(new Coordinator());
            }
            var user= coordinator.User;
            user.UserName = user.Email;

            IdentityResult result = _userManager.CreateAsync(user, user.PasswordHash).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Coordinator").GetAwaiter().GetResult();
            }
            var coordinatorProfile = new Coordinator();
            coordinatorProfile.UserId = user.Id;
            coordinatorProfile.Department = coordinator.Department;
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
            var coordinatorinDb = _db.Coordinators.Include(x=>x.User)
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
