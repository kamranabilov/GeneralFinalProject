using FianlProject.DAL;
using FianlProject.Extensions;
using FianlProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	//[Authorize(Roles = "Admin")]
	public class FaqController : Controller
    {
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;

		public FaqController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
		public IActionResult Index()
        {
			List<Faq> faqs = _context.Faqs.ToList();
			_context.SaveChanges();
			return View(faqs);
        }

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0) return NotFound();
			Faq faq = _context.Faqs.FirstOrDefault(c => c.Id == id);
			if (faq == null) return NotFound();
			return View(faq);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Edit(int? id, Faq newfaq)
		{
			if (id == null || id == 0) return NotFound();
			if (!ModelState.IsValid) return View();
			Faq existed = await _context.Faqs.FirstOrDefaultAsync(x => x.Id == id);
			if (existed == null) return BadRequest();
			_context.Entry(existed).CurrentValues.SetValues(newfaq);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
