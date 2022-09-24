﻿using FianlProject.DAL;
using FianlProject.Extensions;
using FianlProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
	[Authorize(Roles = "Admin")]
	public class SettingController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;

		public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
			_env = env;
		}
        public IActionResult Index()
        {
            List<Setting> model = _context.Settings.ToList();
            return View(model);
        }

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || id == 0) return NotFound();
			Setting setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
			if (setting == null) return NotFound();
			return View(setting);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Edit(int? id, Setting setting)
		{
			if (id == null || id == 0) return NotFound();
			if (!ModelState.IsValid) return View();
			Setting existed = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
			if (existed == null) return BadRequest();
			_context.Entry(existed).CurrentValues.SetValues(setting);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
