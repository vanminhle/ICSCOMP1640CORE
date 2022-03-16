using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ICSCOMP1640CORE.Controllers
{
    [Authorize(Roles = Role.Staff)]
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


        public async Task<IActionResult> IdeaIndex()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var ideaInDb = _db.Ideas
                .Include(y => y.Category)
                .Include(y => y.Department)
                .Include(y => y.User)
                .Where(y => y.DepartmentId == currentUser.DepartmentId)
                .ToList();
            return View(ideaInDb);
        }

        [HttpGet]
        public async Task<IActionResult> IdeaDetail(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var ideaInDb = _db.Ideas
               .Include(y => y.Category)
               .Include(y => y.Department)
               .Include(y => y.User)
               .Where(y => y.DepartmentId == currentUser.DepartmentId)
               .SingleOrDefault(y => y.Id == id);

            return View(ideaInDb);
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

            return RedirectToAction("IdeaDetail","Staffs");
        }

        [HttpGet]
        public IActionResult CreateIdea()
        {
            Idea model = new Idea();
            var categoryList = _db.Categories.Select(x => new { x.Id, x.Name }).ToList();
            var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.categoryList = new SelectList(categoryList, "Id", "Name");
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIdea(Idea idea, IFormFile file)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userManager.GetUserAsync(User);
            if (idea.CategoryId == 0)
            {
                _notyf.Warning("Please choose Category for idea!.");
                return RedirectToAction("CreateIdea");
            }

            //File

            if (file != null && file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    var extensionCheck = Path.GetExtension(file.FileName);
                    if (extensionCheck != ".pdf")
                    {
                        _notyf.Warning("Your document need to submit in .pdf");
                        return RedirectToAction("CreateIdea");
                    }
                    else
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        idea.Document = fileBytes;
                        // act on the Base64 data
                    }
                }
            }

            var model = new Idea();
            {
                model.UserId = userId;
                model.Id = idea.Id;
                model.CategoryId = idea.CategoryId;
                model.IdeaName = idea.IdeaName;
                model.Content = idea.Content;
                model.SubmitDate = idea.SubmitDate;
                model.DepartmentId = currentUser.DepartmentId;
                model.IsAnonymous = idea.IsAnonymous;
                model.Document = idea.Document;
            }

            _db.Ideas.Add(model);
            _db.SaveChanges();
            _notyf.Success("Idea is created successfully.");
            return RedirectToAction("IdeaIndex");
        }

        [HttpGet]
        public IActionResult DeleteIdea(int id)
        {
            var ideaInDb = _db.Ideas.SingleOrDefault(item => item.Id == id);
            _db.Ideas.Remove(ideaInDb);
            _db.SaveChanges();
            _notyf.Success("Idea is deleted successfully.");
            return RedirectToAction("IdeaIndex");
        }

        [HttpGet]
        public IActionResult EditIdea(int id)
        {
            var model = _db.Ideas.SingleOrDefault(item => item.Id == id);
            {
                var category = _db.Categories.ToList();
                var categoryList = _db.Categories.Select(x => new { x.Id, x.Name }).ToList();
                var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.categoryList = new SelectList(categoryList, "Id", "Name");
                ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditIdea(Idea idea)
        {
            if (idea.CategoryId == 0)
            {
                _notyf.Warning("Please choose Category for idea!.");
                return RedirectToAction("CreateIdea");
            }
            var ideainDb = _db.Ideas.Include(x => x.Category)
                .SingleOrDefault(item => item.Id == idea.Id);
            ideainDb.Id = idea.Id;
            ideainDb.CategoryId = idea.CategoryId;
            ideainDb.IdeaName = idea.IdeaName;
            ideainDb.Content = idea.Content;
            ideainDb.SubmitDate = idea.SubmitDate;
            _db.SaveChanges();
            _notyf.Success("Idea is edited successfully.");
            return RedirectToAction("IdeaIndex");
        }
        public ActionResult InforStaff(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            id = userId.ToString();
            var StaffInDb = _db.Users.Include("Department").SingleOrDefault(i => i.Id == id);
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