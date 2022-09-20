using FianlProject.DAL;
using FianlProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FianlProject.Controllers
{
	public class ContactController : Controller
	{
		private readonly AppDbContext _context;

		public ContactController(AppDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		//[HttpPost]
		//[AutoValidateAntiforgeryToken]
		//public async Task<IActionResult> Contact(Message message)
		//{
		//	if (!ModelState.IsValid) return View();

		//	if (User.IsInRole("Admin") || User.IsInRole("Moderator"))
		//	{
		//		ModelState.AddModelError(string.Empty, "Only Member and guests are allowed to send emails.");
		//		return View();
		//	}
		//	_context.Messages.Add(message);
		//	await _context.SaveChangesAsync();

		//	TempData["Successfull"] = "Your message has been send successfully!";
		//	return RedirectToAction(nameof(Index));
		//}
	}
}
