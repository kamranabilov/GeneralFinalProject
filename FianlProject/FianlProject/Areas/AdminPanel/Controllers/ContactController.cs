using FianlProject.DAL;
using FianlProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FianlProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
			//List<Contact> contacts = _context.Contact.ToList();
			return View();
        }
    }
}
