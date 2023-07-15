using doan.Models;
using doan.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LienHeController : Controller
    {
        private readonly DataContext _context;
        public LienHeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiLH()
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            var lh = _context.LienHes.ToList();
            return View(lh);    
        }
        
    }
}
