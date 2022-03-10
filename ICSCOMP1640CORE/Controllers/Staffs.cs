﻿using Microsoft.AspNetCore.Mvc;
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
namespace ICSCOMP1640CORE.Controllers
{
    public class Staffs : Controller
    {
        private ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public Staffs(ApplicationDbContext db, INotyfService notyf, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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
    }
}
