using AspNetCoreHero.ToastNotification.Abstractions;
using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using ICSCOMP1640CORE.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
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
        private readonly IEmailSender _emailSender;

        public StaffsController(ApplicationDbContext db, INotyfService notyf, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _notyf = notyf;
            _emailSender = emailSender;
        }


        public async Task<IActionResult> IdeaIndex(string sortOrder, string searchString, int pg = 1)
        {

            var currentUser = await _userManager.GetUserAsync(User);

            var ideaInDb = _db.Ideas
                .Include(y => y.Category)
                .Include(y => y.Department)
                .Include(y => y.User)
                .Include(y => y.Comments)
                .Where(y => y.DepartmentId == currentUser.DepartmentId)
                .ToList();

            //Sort

            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortbyView = String.IsNullOrEmpty(sortOrder) ? "view_sort" : "view_sort";
            ViewBag.SortbyRating = String.IsNullOrEmpty(sortOrder) ? "rating_sort" : "rating_sort";
            ViewBag.SortbyLatest = String.IsNullOrEmpty(sortOrder) ? "latest_sort" : "latest_sort";
            ViewBag.SortbyThumbUp = String.IsNullOrEmpty(sortOrder) ? "thumbup_sort" : "thumbup_sort";
            ViewBag.SortbyThumbDown = String.IsNullOrEmpty(sortOrder) ? "thumbdown_sort" : "thumbdown_sort";
            ViewBag.SortbyComment = String.IsNullOrEmpty(sortOrder) ? "comment_sort" : "comment_sort";

            switch (sortOrder)
            {
                case "view_sort":
                    ideaInDb = ideaInDb.OrderByDescending(w => w.View).ToList();
                    break;
                case "rating_sort":
                    ideaInDb = ideaInDb.OrderByDescending(w => w.Rating).ToList();
                    break;
                case "latest_sort":
                    ideaInDb = ideaInDb.OrderByDescending(w => w.SubmitDate).ToList();
                    break;
                case "thumbup_sort":
                    ideaInDb = ideaInDb.OrderByDescending(w => w.ThumbUp).ToList();
                    break;
                case "thumbdown_sort":
                    ideaInDb = ideaInDb.OrderByDescending(w => w.ThumbDown).ToList();
                    break;
                case "comment_sort":
                    ideaInDb = ideaInDb.OrderByDescending(w => w.Comments.Count).ToList();
                    break;
                default:
                    ideaInDb.OrderBy(n => n.IdeaName);
                    break;
            }


            //Search
            if (!String.IsNullOrEmpty(searchString))
            {
                ideaInDb = ideaInDb
                    .Where(s => s.IdeaName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    s.User.FullName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                    )
                .ToList();
            }

            //Pagination
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = ideaInDb.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = ideaInDb.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);

            //return View(ideaInDb);
        }

        [HttpGet]
        public async Task<IActionResult> IdeaDetail(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.id = userId;
            var commentInDb = _db.Comments.OrderByDescending(c => c.CreatedAt).Include(x => x.User).ToList();
            var currentUser = await _userManager.GetUserAsync(User);
            var ideaInDb = _db.Ideas
               .Include(y => y.Category)
               .Include(y => y.Department)
               .Include(y => y.Comments)
               .Include(y => y.User)
               .Where(y => y.DepartmentId == currentUser.DepartmentId)
               .SingleOrDefault(y => y.Id == id);
            ideaInDb.View++;
            _db.SaveChanges();
            return View(ideaInDb);
        }

        [HttpGet]
        public IActionResult DownloadDocumentIdea(int id)
        {
            var ideaInDb = _db.Ideas.Include(y => y.Department).Include(y => y.User).SingleOrDefault(y => y.Id == id);

            if (ideaInDb.Document != null)
            {
                byte[] fileBytes = ideaInDb.Document;

                return File(
                    fileBytes,         /*byte []*/
                    "application/pdf", /*mime type*/
                    $"DocumentFile_(Staff-{ideaInDb.User.FullName})-(Department-{ideaInDb.Department.Name}).pdf");    /*name of the file*/
            }

            return RedirectToAction("IdeaDetail","Staffs");
        }

        [HttpGet]
        public IActionResult CreateIdea()
        {
            DateTime createTime = DateTime.Now;

            var PeriodNow = _db.AcademicIdeaPeriods.SingleOrDefault(x => x.Id == 1);
            int DateTimeCompare = DateTime.Compare(createTime, PeriodNow.ClosureDate);

            if (DateTimeCompare > 0)
            {
                _notyf.Error($"You cant Create New Idea! Because the time for giving new Idea is end! {PeriodNow.ClosureDate.ToShortDateString()}");
                return RedirectToAction("IdeaIndex");
            }

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

            //Email
            var currentDepartmentId = currentUser.DepartmentId;
            var dataCoordinator = _userManager.GetUsersInRoleAsync("Coordinator").Result.ToList();
            var departmentCoordinator = dataCoordinator.Where(x => x.DepartmentId == currentDepartmentId);
            foreach (var user in departmentCoordinator)
            {
                _db.Entry(user).Reference(x => x.Department).Load();
                await _emailSender.SendEmailAsync(
                user.Email,
                $"Your Department Have New Idea Submit by {user.FullName}",
                $"Hi, {user.FullName}, Your Department {currentUser.Department.Name} have new Idea ({idea.IdeaName}) submitted by ({user.FullName}) in ({idea.SubmitDate.ToString("dd / mm / yyyy hh: mm tt")})");
            }

            _db.Ideas.Add(model);
            _db.SaveChanges();
            _notyf.Success("Your Idea is created successfully.");
            return RedirectToAction("IdeaIndex");
        }

        [HttpGet]
        public IActionResult DeleteIdea(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ideaInDb = _db.Ideas.SingleOrDefault(item => item.Id == id);

            if (ideaInDb.UserId != userId)
            {
                _notyf.Error("You do not have permission to delete idea of other person!");
                return RedirectToAction("IdeaIndex");
            }

            _db.Ideas.Remove(ideaInDb);
            _db.SaveChanges();
            _notyf.Success("Idea is deleted successfully.");
            return RedirectToAction("IdeaIndex");
        }

        [HttpGet]
        public IActionResult EditIdea(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _db.Ideas.SingleOrDefault(item => item.Id == id);

            if (model.UserId != userId)
            {
                _notyf.Error("You do not have permission to edit idea of other person!");
                return RedirectToAction("IdeaIndex");
            }

            var category = _db.Categories.ToList();
            var categoryList = _db.Categories.Select(x => new { x.Id, x.Name }).ToList();
            var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.categoryList = new SelectList(categoryList, "Id", "Name");
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult EditIdea(Idea idea, IFormFile file)
        {
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

            var ideainDb = _db.Ideas.Include(x => x.Category)
                .SingleOrDefault(item => item.Id == idea.Id);
            ideainDb.Id = idea.Id;
            ideainDb.CategoryId = idea.CategoryId;
            ideainDb.IdeaName = idea.IdeaName;
            ideainDb.Content = idea.Content;
            ideainDb.SubmitDate = idea.SubmitDate;
            ideainDb.Document = idea.Document;

            _db.SaveChanges();
            _notyf.Success("Idea is edited successfully.");
            return RedirectToAction("IdeaIndex");
        }

        [HttpGet]
        public IActionResult LikeIdea(int id)
        {
            var currentIdeaInDb = _db.Ideas.Include("User")
                .Include("Department")
                .Include("Category")
                .Include(y => y.Comments)
                .FirstOrDefault(x => x.Id == id);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentActionOnDb = _db.UserActionOnIdeas.FirstOrDefault(x => x.UserId == userId && x.IdeaId == id);
            var isAction = _db.UserActionOnIdeas.Any(x => x.IdeaId == id && x.UserId == userId);

            if (isAction == false)
            {
                currentIdeaInDb.ThumbUp++;

                var ideaLike = new UserActionOnIdea()
                {
                    UserId = userId,
                    IdeaId = id,
                    IsLike = true,
                    IsDisLike = false,
                };
                _db.UserActionOnIdeas.Add(ideaLike);

                _db.SaveChanges();
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else if (isAction == true && (currentActionOnDb.IsLike == true && currentActionOnDb.IsDisLike == false))
            {
                _notyf.Error("You already Like this Idea!");
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else if (isAction == true && (currentActionOnDb.IsLike == false && currentActionOnDb.IsDisLike == true))
            {
                currentIdeaInDb.ThumbUp++;
                currentIdeaInDb.ThumbDown--;
                currentActionOnDb.IsLike = true;
                currentActionOnDb.IsDisLike = false;

                _db.SaveChanges();
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public IActionResult DisLikeIdea(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentActionOnDb = _db.UserActionOnIdeas.FirstOrDefault(x => x.UserId == userId && x.IdeaId == id);
            var currentIdeaInDb = _db.Ideas.Include("User")
                    .Include("Department")
                    .Include(y => y.Comments)
                    .Include("Category")
                    .FirstOrDefault(x => x.Id == id);
            var isAction = _db.UserActionOnIdeas.Any(x => x.IdeaId == id && x.UserId == userId);

            if (isAction == false)
            {
                currentIdeaInDb.ThumbDown++;

                var ideaDisLike = new UserActionOnIdea()
                {
                    UserId = userId,
                    IdeaId = id,
                    IsLike = false,
                    IsDisLike = true,
                };
                _db.UserActionOnIdeas.Add(ideaDisLike);

                _db.SaveChanges();
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else if (isAction == true && (currentActionOnDb.IsLike == false && currentActionOnDb.IsDisLike == true))
            {

                _notyf.Error("You already DisLike this Idea!");
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else if (isAction == true && (currentActionOnDb.IsLike == true && currentActionOnDb.IsDisLike == false))
            {
                currentIdeaInDb.ThumbDown++;
                currentIdeaInDb.ThumbUp--;

                currentActionOnDb.IsDisLike = true;
                currentActionOnDb.IsLike = false;
                _db.SaveChanges();
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return Redirect(Request.Headers["Referer"].ToString());
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

            /*var departmentList = _db.Departments.Select(x => new { x.Id, x.Name }).ToList();
            ViewBag.departmentList = new SelectList(departmentList, "Id", "Name");*/
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
            StaffInDb.DepartmentId = StaffInDb.DepartmentId;
            StaffInDb.PhoneNumber = staff.PhoneNumber;

            _db.Update(StaffInDb);
            _db.SaveChanges();
            _notyf.Success("Manager account is edited successfully.");
            return RedirectToAction("InforStaff");
        }


        // COMMENTS
        public async Task<IActionResult> ViewComments()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var CommentInDb = _db.Comments
                .Include(y => y.User)
                .ToList();
            return View(CommentInDb);
        }

        [HttpGet]
        public IActionResult CreateComments(int id)
        {
            DateTime createTime = DateTime.Now;

            var PeriodNow = _db.AcademicIdeaPeriods.SingleOrDefault(x => x.Id == 1);
            int DateTimeCompare = DateTime.Compare(createTime, PeriodNow.FinalClosureDate);

            if (DateTimeCompare > 0)
            {
                _notyf.Error($"You cant Give any Comment! Because the time for giving comment is end! {PeriodNow.FinalClosureDate.ToShortDateString()}");
                return Redirect(Request.Headers["Referer"].ToString());
            }

            Comment model = new();
            var Comment = _db.Comments.Select(x => new { x.Id }).ToList();
            var infoIdea = _db.Ideas.OfType<Idea>().FirstOrDefault(t => t.Id == id);
            var Ideal = _db.Ideas.Select(x => new { x.Id }).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComments(Comment comment, int id)
        {
            var currentIdeaInDb = _db.Ideas.Include("User")
                .Include("Department")
                .Include("Category")
                .Include(y => y.Comments)
                .FirstOrDefault(x => x.Id == id);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var infoIdea = _db.Ideas.OfType<Idea>().FirstOrDefault(t => t.Id == id);
            var currentUser = await _userManager.GetUserAsync(User);
            var model = new Comment();
            {

                model.IdeaId = infoIdea.Id;
                model.UserId = userId;
                model.Content = comment.Content;
                model.CreatedAt = comment.CreatedAt;
            }

            await _emailSender.SendEmailAsync(
            infoIdea.User.Email,
            $"Your Idea ({infoIdea.IdeaName}) Have New Comment Submit by ({currentUser.FullName})",
            $"Hi, {infoIdea.User.FullName}, Your Idea {infoIdea.IdeaName} have new comment by ({currentUser.FullName}) in ({comment.CreatedAt.ToString("dd / mm / yyyy hh: mm tt")}) with content ({comment.Content})");

            _db.Comments.Add(model);
            _db.SaveChanges();
            _notyf.Success("Comment is created successfully.");
            return RedirectToAction("IdeaDetail", "Staffs", new { id = infoIdea.Id });
        }

        [HttpGet]
        public IActionResult DeleteComment(int id)
        {
            var commentInDb = _db.Comments.SingleOrDefault(c => c.Id == id);
            if (commentInDb == null)
            {
                return NotFound();
            }
            _db.Comments.Remove(commentInDb);
            _db.SaveChanges();
            _notyf.Success("Comment is deleted successfully.", 3);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public IActionResult EditComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var commentInDb = _db.Comments.SingleOrDefault(c => c.Id == id);
            if (commentInDb == null)
            {
                return NotFound();
            }
            return View(commentInDb);
        }

        [HttpPost]
        public IActionResult EditComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }
            var commentInDb = _db.Comments.SingleOrDefault(c => c.Id == comment.Id);
            if (commentInDb == null)
            {
                return NotFound();
            }
            commentInDb.Content = comment.Content;
            _db.SaveChanges();
            _notyf.Success("Comment is edited successfully.", 3);
            return RedirectToAction("IdeaIndex");
        }
    }
}
