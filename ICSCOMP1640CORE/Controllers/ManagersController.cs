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
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.IO.Compression;

namespace ICSCOMP1640CORE.Areas.Identity.Pages.Account.Manage
{
	[Authorize(Roles = Role.Manager)]
	public class ManagersController : Controller
	{
		private ApplicationDbContext _db;
		private readonly INotyfService _notyf;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public ManagersController(ApplicationDbContext db, INotyfService notyf, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_notyf = notyf;
		}

		//Manage Idea Category
		[HttpGet]
		public IActionResult ManageCategories(string searchCategory, int pg = 1)
		{
			var categoryInDb = _db.Categories.ToList();
			if (!String.IsNullOrEmpty(searchCategory))
			{
				categoryInDb = categoryInDb.FindAll(s => s.Name.Contains(searchCategory));
			}
			//return View(categoryInDb);

			//Pagination
			const int pageSize = 6;
			if (pg < 1)
				pg = 1;

			int recsCount = categoryInDb.Count();

			var pager = new Pager(recsCount, pg, pageSize);

			int recSkip = (pg - 1) * pageSize;

			var pageData = categoryInDb.Skip(recSkip).Take(pager.PageSize).ToList();

			this.ViewBag.Pager = pager;

			return View(pageData);
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateCategory(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View("CreateCategory");
			}
			var check = _db.Categories.Any(c => c.Name.Equals((category.Name).Trim()));
			if (check)
			{
				_notyf.Warning("Category is already exists.", 3);
				return View(category);
			}
			var newCategoryInDb = new Category
			{
				Name = category.Name.Trim(),
				Description = category.Description,
			};
			_db.Categories.Add(newCategoryInDb);
			_db.SaveChanges();
			_notyf.Success("Category is created successfully.", 3);
			return RedirectToAction("ManageCategories", "Managers");
		}

		[HttpGet]
		public IActionResult DeleteCategory(int id)
		{
			var categoryInDb = _db.Categories.SingleOrDefault(c => c.Id == id);
			var ideaInDb = _db.Ideas.ToList();

			if (categoryInDb == null)
			{
				return NotFound();
			}

			foreach (var idea in ideaInDb)
			{
				if(idea.CategoryId == id)
				{
					_notyf.Error("Category is already used in Idea!", 3);
					return RedirectToAction("ManageCategories", "Managers");
				}
			}

			_db.Categories.Remove(categoryInDb);
			_db.SaveChanges();
			_notyf.Success("Category is deleted successfully.", 3);
			return RedirectToAction("ManageCategories", "Managers");
		}

		[HttpGet]
		public IActionResult EditCategory(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var categoryInDb = _db.Categories.SingleOrDefault(c => c.Id == id);
			if (categoryInDb == null)
			{
				return NotFound();
			}
			return View(categoryInDb);
		}

		[HttpPost]
		public IActionResult EditCategory(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View(category);
			}
			var categoryInDb = _db.Categories.SingleOrDefault(c => c.Id == category.Id);
			if (categoryInDb == null)
			{
				return NotFound();
			}
			var check = _db.Categories.Any(c => c.Name.Equals((category.Name).Trim()));
			if (check)
			{
				_notyf.Warning("Category is already exists", 3);
				return View(category);
			}
			categoryInDb.Name = category.Name.Trim();
			categoryInDb.Description = category.Description;
			_db.SaveChanges();
			_notyf.Success("Category is edited successfully.", 3);
			return RedirectToAction("ManageCategories", "Managers");
		}
		//Coordinator
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
		public ActionResult InforCoordinator(string id)
		{
			var CoordinatorInDb = _db.Users.OfType<User>().Include("Department").FirstOrDefault(t => t.Id == id);
			if (CoordinatorInDb == null)
			{
				return NotFound();
			}
			return View(CoordinatorInDb);
		}

		[HttpGet]
		public ActionResult InforStaff(string id)
		{
			var info = _db.Users.OfType<User>().Include("Staff").FirstOrDefault(t => t.Id == id);
			if (info == null)
			{
				return NotFound();
			}
			return View(info);
		}

		[HttpGet]
		public ActionResult InforManager(string id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			id = userId.ToString();
			var ManagerInDb = _db.Users.SingleOrDefault(i => i.Id == id);
			if (ManagerInDb == null)
			{
				return NotFound();
			}
			return View(ManagerInDb);
		}

		[HttpGet]
		public ActionResult EditProfile(string Id)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			Id = userId.ToString();
			var ManagerInDb = _db.Users.SingleOrDefault(i => i.Id == Id);

			return View(ManagerInDb);
		}

		[HttpPost]
		public ActionResult EditProfile(Manager manager, string id)
		{
			var ManagerInDb = _db.Users.OfType<User>().FirstOrDefault(t => t.Id == id);

			if (ManagerInDb == null)
			{
				return BadRequest();
			}

			ManagerInDb.FullName = manager.FullName;
			ManagerInDb.Address = manager.Address;
			ManagerInDb.Age = manager.Age;
			ManagerInDb.Gender = manager.Gender;
			ManagerInDb.DepartmentId = 1;
			ManagerInDb.PhoneNumber = manager.PhoneNumber;

			_db.Update(ManagerInDb);
			_db.SaveChanges();
			_notyf.Success("Manager account is edited successfully.");
			return RedirectToAction("InforManager");
		}

		[HttpGet]
		public IActionResult ManageIdea(string sortOrder, string searchString, int pg = 1)
		{
			var ideaInDb = _db.Ideas.Include(x => x.User).Include(x=>x.Department).Include(x => x.Comments).ToList();
			var categoryInDb = _db.Categories.ToList();
			if (!String.IsNullOrEmpty(searchString))
			{
				ideaInDb = ideaInDb
					.Where(s => s.IdeaName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
					.ToList();

			}

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
		}

		[HttpGet]
		public IActionResult ViewDetailIdea(int Id)
		{
			var commentInDb = _db.Comments.OrderByDescending(c => c.CreatedAt).Include(x => x.User).ToList();
			var ideaInDb = _db.Ideas
			   .Include(y => y.Category)
			   .Include(y => y.Department)
			   .Include(y => y.Comments)
			   .Include(y => y.User)
			   .SingleOrDefault(y => y.Id == Id);
			return View(ideaInDb);
		}

		[HttpGet]
		public IActionResult DeleteAllIdea()
		{
			var ideaInDb = _db.Ideas;
			var commentInDb = _db.Comments;
			if (ideaInDb == null)
			{
				return NotFound();
			}
			_db.Ideas.RemoveRange(ideaInDb);
			_db.Comments.RemoveRange(commentInDb);
			_db.SaveChanges();
			_notyf.Success("All idea is deleted successfully.", 3);
			return RedirectToAction("ManageIdea", "Managers");
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
					$"DocumentFile_(Staff-{currentUser.FullName})-(Department-{currentUser.Department}).pdf");    /*name of the file*/
			}

			return RedirectToAction("ViewDetailIdea", "Managers");
		}

		[HttpGet]
		public IActionResult DepartmentStatistics(string searchString, int pg = 1)
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
		public IActionResult ViewStatistics(int id)
		{

			// check number of idea
			var idea = _db.Ideas.Where(x => x.DepartmentId == id).ToList().Count();
			ViewBag.number = idea;

			// check anony
			var ideaAnonymous = _db.Ideas.Where(x => x.DepartmentId == id).Where(x => x.IsAnonymous == true).ToList().Count();
			ViewBag.IsAnonymous = ideaAnonymous;

			// check number of idea without cmt
			var ideaList = _db.Ideas.Where(x => x.DepartmentId == id).Include(y => y.Comments).ToList() ;

			int noCommentCount = 0;
			foreach (var item in ideaList)
			{
				if (item.Comments.Count == 0)
				{
					noCommentCount++;
				}
			}
			ViewBag.noCmt = noCommentCount;

			// check number of contributor
			int userIdeaCount = 0;
			string[] userString = new string[0];
			foreach (var item in ideaList)
			{
				if (userString.Contains(item.UserId) == false)
				{
					userIdeaCount++;
					userString = userString.Concat(new[] { item.UserId }).ToArray();
				}
			}

			ViewBag.userGiveIdea = userIdeaCount;
			return View();
		}

		[HttpGet]
		public IActionResult DownloadAsCsv()
		{
			var ideaInDb = _db.Ideas.Include(u => u.User).Include(u => u.Department).Include(c => c.Category).ToList();
			var builder = new StringBuilder();
			builder.AppendLine("Idea Name, Category, SubmitIn, Author, Email, Address, PhoneNumber, Age, Gender, Department, Rating, ThumbUp, ThumbDown, View, Content");
			foreach(var idea in ideaInDb)
			{
				builder.AppendLine($"{idea.IdeaName},{idea.Category.Name},{idea.SubmitDate}," +
					$"{idea.User.FullName},{idea.User.Email},{idea.User.Address},{idea.User.PhoneNumber}," +
					$"{idea.User.Age},{idea.User.Gender},{idea.Department.Name},{idea.Rating},{idea.ThumbUp}," +
					$"{idea.ThumbDown},{idea.View}," +
					$"{idea.Content.Replace(System.Environment.NewLine, ". ").Replace(",", ";")}");
			}

			return (File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "IdeaData.csv"));
		}


		[HttpGet]
		public IActionResult DownloadIdeaZip()
		{
			var ideaInDb = _db.Ideas.Include(u => u.User).Include(u => u.Department).Include(c => c.Category).ToList();

			using (MemoryStream ms = new MemoryStream())
			{
				using (var archive = new ZipArchive(ms, ZipArchiveMode.Create, true))
				{
					foreach (var file in ideaInDb)
					{
						if (file.Document != null)
						{
							var entry = archive.CreateEntry(file.User.FullName + "-" + file.IdeaName + "-" + file.Department.Name + ".pdf", CompressionLevel.Fastest);
							using (var zipStream = entry.Open())
							{
								zipStream.Write(file.Document, 0, file.Document.Length);
							}
						}

					}
				}
				return File(ms.ToArray(), "application/zip", "Archive.zip");
			}
		}

	}
}
