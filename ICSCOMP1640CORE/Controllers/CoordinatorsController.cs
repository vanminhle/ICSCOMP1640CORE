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
        public async Task<IActionResult> ManageStaffs(string searchString, int pg = 1)
        {

            /*var coordinatorInDb = _db.Users.OfType<User>().Include(x => x.Department)
                .Where(m => m.DepartmentId == currentDepartmentId)
                .ToList();*/


            var currentUser = await _userManager.GetUserAsync(User);
            var currentDepartmentId = currentUser.DepartmentId;
            var dataStaff = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
            var data = dataStaff.Where(x => x.DepartmentId == currentDepartmentId);
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
            var CoordinatorInDb = _db.Users.Include("Department").SingleOrDefault(i => i.Id == id);

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
            coordinatorinDb.DepartmentId = coordinatorinDb.DepartmentId;
            coordinatorinDb.PhoneNumber = coordinator.PhoneNumber;

            _db.Update(coordinatorinDb);
            _db.SaveChanges();
            _notyf.Success("Coordinator account is edited successfully.");
            return RedirectToAction("InforCoordinator");
        }

        [HttpGet]
        public async Task<IActionResult> GetIdeaFromCoor(string searchString, int pg = 1)
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var ideaInDb = _db.Ideas.Include(x => x.Department)
                .Include(x => x.Category)
                .Include(x => x.User)
                .Where(x => x.DepartmentId == currentUser.DepartmentId)
                .ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                ideaInDb = ideaInDb
                    .Where(s => s.IdeaName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();
            }
            //Pagination
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = ideaInDb.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var pageData = ideaInDb.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(pageData);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadDocumentIdea(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var ideaInDb = _db.Ideas.SingleOrDefault(y => y.Id == id);

            if (ideaInDb.Document != null)
            {
                byte[] fileBytes = ideaInDb.Document;

                return File(
                    fileBytes,         /*byte []*/
                    "application/pdf", /*mime type*/
                    $"DocumentFile_(Staff{currentUser.FullName})(Department-{currentUser.Department}).pdf");    /*name of the file*/
            }

            return RedirectToAction("DetailIdea", "Admins");
        }

        [HttpGet]
        public IActionResult ViewIdea(int id)
        {
            var idea = _db.Ideas.Include(x => x.User).SingleOrDefault(item => item.Id == id);
            var ideaInDb = _db.Ideas
               .Include(y => y.Category)
               .Include(y => y.Department)
               .Include(y => y.Comments)
               .Include(y => y.User)
               .SingleOrDefault(y => y.Id == id);
            return View(ideaInDb);
        }

        [HttpGet]
        public IActionResult DeleteIdea(int id)
        {
            var ideaInDb = _db.Ideas.SingleOrDefault(x => x.Id == id);
            if (ideaInDb == null)
            {
                return NotFound();
            }
            _notyf.Success("Idea is deleted successfully.", 3);
            _db.Ideas.Remove(ideaInDb);
            _db.SaveChanges();
            return RedirectToAction("GetIdeaFromCoor", "Coordinators");
        }

        //Statistics
        [HttpGet]
        public async Task<IActionResult> DataStatistics()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentDepartmentId = currentUser.DepartmentId;

            // check idea
            var idea = _db.Ideas.Where(x => x.DepartmentId == currentDepartmentId).ToList().Count();
            ViewBag.number = idea;

            // check anony
            var ideaAnonymous = _db.Ideas.Where(x => x.DepartmentId == currentDepartmentId).Where(x => x.IsAnonymous == true).ToList().Count();
            ViewBag.IsAnonymous = ideaAnonymous;

            // check nocmt idea
            var ideaList = _db.Ideas.Where(x => x.DepartmentId == currentDepartmentId).ToList();

            int noCommentCount = 0;
            foreach (var item in ideaList)
            {
                if(item.Comments == null)
                {
                    noCommentCount++;
                }
            }
            ViewBag.noCmt = noCommentCount;

            // check how many user give idea
            int userIdeaCount = 0;
            string currentUserId = "";
            foreach (var item in ideaList)
            {
                if (item.UserId != currentUserId)
                {
                    userIdeaCount++;
                    currentUserId = item.UserId;
                }
            }

            ViewBag.userGiveIdea = userIdeaCount;

            return View();
        }

    }

}
