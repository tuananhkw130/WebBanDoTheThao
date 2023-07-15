using doan.Models;
using doan.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaiVietController : Controller
    {
        private readonly DataContext _context;
        public BaiVietController(DataContext context)
        {
            _context = context;
        }

        public IActionResult HienThiBV()
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            var bv = _context.BaiViets.ToList();
            return View(bv);    
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
        public IActionResult Them(BaiViet bv)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            bv.IDNguoiTao = Functions._UserID;
            _context.BaiViets.Add(bv);
            _context.SaveChanges();
            return RedirectToAction("HienThiBV");
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
            var bv = _context.BaiViets.Find(id);
            return View(bv);
        }
        [HttpPost]
        public IActionResult Sua(BaiViet bv)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.BaiViets.Update(bv);
            _context.SaveChanges();
            return RedirectToAction("HienThiBV");
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
            var bv = _context.BaiViets.Find(id);
            return View(bv);

        }
        [HttpPost]
        public IActionResult Xoa(BaiViet bv)
        {
            if (Functions._Admin != true)
            {
                return NotFound();
            }
            _context.BaiViets.Remove(bv);
            _context.SaveChanges();
            return RedirectToAction("HienThiBV");
        }
    }
}
