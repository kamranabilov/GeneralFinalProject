using FianlProject.DAL;
using FianlProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace FianlProject.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }
        public List<Setting> getSettings()
        {
            List<Setting> settings = _context.Settings.ToList();
            return settings;
        }
    }
}
