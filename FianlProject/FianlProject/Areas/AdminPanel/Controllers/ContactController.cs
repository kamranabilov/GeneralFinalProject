using FianlProject.DAL;
using FianlProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FianlProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
	[Authorize(Roles = "Admin")]
	public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList();
			foreach (Contact item in  contacts)
			{
				item.Here = true;
			}
			_context.SaveChanges();
            return View(contacts);

        }

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id == 0) return NotFound();
			Contact contact = await _context.Contacts.FindAsync(id);
			if (contact == null) return NotFound();
			_context.Contacts.Remove(contact);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
