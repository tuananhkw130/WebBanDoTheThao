using doan.Models;
using doan.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;
        public MenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiDS()
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            var dsmenu = _context.Menus.ToList();
            return View(dsmenu);    
        }
        public IActionResult Them()
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Them(Menu menu)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.Menus.Add(menu);
            _context.SaveChanges();
            return RedirectToAction("HienThiDS");
        }
        public IActionResult Sua(int id)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var menu = _context.Menus.Find(id);
            return View(menu);
        }
        [HttpPost]
        public IActionResult Sua(Menu menu)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.Menus.Update(menu);
            _context.SaveChanges();
            return RedirectToAction("HienThiDS");
        }
        public IActionResult Xoa(int id)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var menu = _context.Menus.Find(id);
            return View(menu);

        }
        [HttpPost]
        public IActionResult Xoa(Menu menu)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.Menus.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction("HienThiDS");
        }
    }
}
