using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using doan.Utilities;

namespace doan.Controllers
{
    public class TaiKhoanController : Controller
    {
       
        private readonly DataContext _context;
        public TaiKhoanController( DataContext context)
        {
           
            _context = context;
        }

        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult XLDangKy(NguoiDung nd)
        {
            nd.MatKhau=Functions.MD5Password(nd.MatKhau); //mã khoá mật khẩu
            nd.Admin = false;
            nd.TrangThai = true;
            _context.NguoiDungs.Add(nd);
            _context.SaveChanges();
            return RedirectToAction("DangNhap");
        }
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult XLDangNhap(NguoiDung nguoidung)
        {
            nguoidung.MatKhau = Functions.MD5Password(nguoidung.MatKhau);
            var nd = _context.NguoiDungs.Where(n => n.TaiKhoan == nguoidung.TaiKhoan).FirstOrDefault();
            if (nd != null && nd.MatKhau == nguoidung.MatKhau)
            {
                Functions._UserID = nd.ID;
                Functions._UserName = nd.HoTen;
                Functions._Admin = nd.Admin;
            }
            else
            {
                TempData["msg"] = "Tài khoản hoặc mật khẩu sai, hãy thử lại";
                return RedirectToAction("DangNhap");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DangXuat()
        {
            Functions._UserID = 0;
            Functions._Admin = false;
            Functions._UserName = String.Empty;
            return RedirectToAction("Index","Home");
        }
    }
}