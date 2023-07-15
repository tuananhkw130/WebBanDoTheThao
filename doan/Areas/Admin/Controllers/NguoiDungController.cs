using doan.Models;
using doan.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NguoiDungController : Controller
    {
        private readonly DataContext _context;
        public NguoiDungController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiND()
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            var nd = _context.NguoiDungs.ToList();
            return View(nd);    
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
        public IActionResult Them(NguoiDung nd)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.NguoiDungs.Add(nd);
            _context.SaveChanges();
            return RedirectToAction("HienThiND");
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
            var nd = _context.NguoiDungs.Find(id);
            return View(nd);
        }
        [HttpPost]
        public IActionResult Sua(NguoiDung nd)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.NguoiDungs.Update(nd);
            _context.SaveChanges();
            return RedirectToAction("HienThiND");
        }
        public IActionResult Xoa(int id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var nd = _context.NguoiDungs.Find(id);
            return View(nd);

        }
        [HttpPost]
        public IActionResult Xoa(NguoiDung nd)
        {
           
            _context.NguoiDungs.Remove(nd);
            _context.SaveChanges();
            return RedirectToAction("HienThiND");
        }
    }
}
