using doan.Models;
using doan.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly DataContext _context;
        public SanPhamController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiSP()
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            var sp =_context.SanPhams.ToList();
            return View(sp);
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
        public IActionResult Them(SanPham sp)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.SanPhams.Add(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
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
            var sp = _context.SanPhams.Find(id);
            return View(sp);
        }
        [HttpPost]
        public IActionResult Sua(SanPham sp)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.SanPhams.Update(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
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
            var sp = _context.SanPhams.Find(id);
            return View(sp);

        }
        [HttpPost]
        public IActionResult Xoa(SanPham sp)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.SanPhams.Remove(sp);
            _context.SaveChanges();
            return RedirectToAction("HienThiSP");
        }
    }
}
