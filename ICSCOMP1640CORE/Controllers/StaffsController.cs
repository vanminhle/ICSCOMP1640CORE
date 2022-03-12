using ICSCOMP1640CORE.Data;
using ICSCOMP1640CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ICSCOMP1640CORE.Controllers
{
    public class StaffsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private ApplicationDbContext _db;
        public StaffsController(ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public IActionResult IdeaIndex()
        {
            var ideaInDb = _db.Ideas.Include(y => y.Category).ToList();

            return View(ideaInDb);
        }

        [HttpGet]
        public IActionResult CreateIdea()
        {
            Idea model = new Idea();
            {
                var category = _db.Categories.ToList();
                var categoryList = _db.Categories.Select(x => new { x.CategoryId, x.CategoryName }).ToList();

                ViewBag.categoryList = new SelectList(categoryList, "CategoryId", "CategoryName");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateIdea(Idea idea)
        {
            var model = new Idea();
            {
                model.IdeaId = idea.IdeaId;
                model.CategoryId = idea.CategoryId;
                model.IdeaName = idea.IdeaName;
                model.IdeaContent = idea.IdeaContent;
                model.SubmitDate = idea.SubmitDate;
            }
            _db.Ideas.Add(model);
            _db.SaveChanges();
            return RedirectToAction("IdeaIndex");
        }

        [HttpGet]
        public IActionResult DeleteIdea(int id)
        {
            var ideaInDb = _db.Ideas.SingleOrDefault(item => item.IdeaId == id);
            _db.Ideas.Remove(ideaInDb);
            _db.SaveChanges();

            return RedirectToAction("IdeaIndex");
        }

        [HttpGet]
        public IActionResult EditIdea(int id)
        {
            var model = _db.Ideas.SingleOrDefault(item => item.IdeaId == id);
            {
                var category = _db.Categories.ToList();
                var categoryList = _db.Categories.Select(x => new { x.CategoryId, x.CategoryName }).ToList();

                ViewBag.categoryList = new SelectList(categoryList, "CategoryId", "CategoryName");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditIdea(Idea idea)
        {
            var ideainDb = _db.Ideas.Include(x => x.Category)
                .SingleOrDefault(item => item.IdeaId == idea.IdeaId);
            {
                ideainDb.IdeaId = idea.IdeaId;
                ideainDb.CategoryId = idea.CategoryId;
                ideainDb.IdeaName = idea.IdeaName;
                ideainDb.IdeaContent = idea.IdeaContent;
                ideainDb.SubmitDate = idea.SubmitDate;
                _db.SaveChanges();
            }
            return RedirectToAction("IdeaIndex");
        }
    }
}
