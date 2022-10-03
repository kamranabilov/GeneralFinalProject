using FianlProject.DAL;
using FianlProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	//[Authorize(Roles = "Member")]
	public class AboutController : Controller
    {
		private readonly AppDbContext _context;
		public AboutController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
			List<About> abouts = _context.Abouts.ToList();
			_context.SaveChanges();
			return View(abouts);
        }

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || id == 0) return NotFound();
			About about = await _context.Abouts.FirstOrDefaultAsync(s => s.Id == id);
			if (about == null) return NotFound();
			return View(about);
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Edit(int? id, Setting setting)
		{
			if (id == null || id == 0) return NotFound();
			if (!ModelState.IsValid) return View();
			About existed = await _context.Abouts.FirstOrDefaultAsync(x => x.Id == id);
			if (existed == null) return BadRequest();
			_context.Entry(existed).CurrentValues.SetValues(existed);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
