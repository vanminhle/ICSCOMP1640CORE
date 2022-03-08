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
namespace ICSCOMP1640CORE.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Coordinator")]
    public class CoordinatorController : Controller
    {

        private ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CoordinatorController(ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        // GET: Coordinator
        [HttpGet]
        public ActionResult InforCoordinator()
        {
            var userId = _userManager.GetUserId(User);
            var coordinatorInDb = _db.Coordinators.Include(x => x.User)
                .SingleOrDefault(t => t.UserId == userId);

            if (coordinatorInDb == null)
            {
                return NotFound();
            }
            return View(coordinatorInDb);

        }
    }
}