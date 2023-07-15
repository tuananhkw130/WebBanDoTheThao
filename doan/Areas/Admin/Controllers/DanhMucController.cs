using doan.Models;
using doan.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucController : Controller
    {
        private readonly DataContext _context;
        public DanhMucController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiDM()
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            var dm = _context.DanhMucs.ToList();
            return View(dm);
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
        public IActionResult Them(DanhMuc dm)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.DanhMucs.Add(dm);
            _context.SaveChanges();
            return RedirectToAction("HienThiDM");
        }
        public IActionResult Sua(int id)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            if (id==null|| id == 0)
            {
                return NotFound();
            }
            var dm = _context.DanhMucs.Find(id);
            return View(dm);
        }
        [HttpPost]
        public IActionResult Sua(DanhMuc dm)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.DanhMucs.Update(dm);
            _context.SaveChanges();
            return RedirectToAction("HienThiDM");
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
            var dm = _context.DanhMucs.Find(id);
            return View(dm);

        }
        [HttpPost]
        public IActionResult Xoa(DanhMuc dm)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.DanhMucs.Remove(dm);
            _context.SaveChanges();
            return RedirectToAction("HienThiDM");
        }
    }
}
