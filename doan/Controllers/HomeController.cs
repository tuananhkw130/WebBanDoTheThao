using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using doan.Utilities;
namespace doan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
      

        public IActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult XLLienHe(LienHe lh)
        {
            lh.NgayTao = DateTime.Now;
            _context.LienHes.Add(lh);
            _context.SaveChanges();
            TempData["msg"] = "Gửi thành công";
            return RedirectToAction("LienHe");
        }

        public IActionResult CuaHang(int? id)
        {

            var sp = _context.SanPhams.ToList();
            ViewBag.TenDM = "Tất cả sản phẩm"; // liên kết sang view
            if(id != null)
            {
                var dm = _context.DanhMucs.Find(id);
                ViewBag.TenDM = dm.TenDanhMuc;
                sp = _context.SanPhams.Where(p=>p.IDDanhMuc==id).ToList();
            }
            return View(sp);
        }

        public IActionResult ChiTietSanPham(int id)
        {
            var sp = _context.SanPhams.Find(id);
            return View(sp);
        }

        public IActionResult DSBaiViet()
        {
            var bv = _context.BaiViets.ToList();
            return View(bv);

        }
        public IActionResult BaiVietChiTiet(int id)
        {
            var bvct= _context.BaiViets.Find(id);
            return View(bvct);
        }
        
        public IActionResult ThemSanPhamVaoGioHang(int SoLuong, int IDSanPhamNguoiDungDatHang)
        {
            if (!Functions.IsLogin())
            {
                TempData["msg"] = "Yêu cầu đăng nhập để sử dụng chức năng này.";
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            int IDNguoiDungDangNhap = Functions._UserID; // gán id người đang đăng nhập vào biến đó
            var spNguoiDungDatTrongGioHang = _context.GioHangs.Where(db => db.IDNguoiDung == IDNguoiDungDangNhap 
            && db.IDSanPham == IDSanPhamNguoiDungDatHang).FirstOrDefault();
            if(spNguoiDungDatTrongGioHang == null) // trường hợp người dùng chưa thêm sp vào giỏ hàng
            {
                var spNguoiDungDatTrongGioHangMoi = new GioHang(); //khởi tạo các thuộc tính trong giỏ hàng với giá trị rỗng
                spNguoiDungDatTrongGioHangMoi.SoLuong = SoLuong;
                spNguoiDungDatTrongGioHangMoi.IDSanPham = IDSanPhamNguoiDungDatHang;
                spNguoiDungDatTrongGioHangMoi.IDNguoiDung = IDNguoiDungDangNhap;

                _context.GioHangs.Add(spNguoiDungDatTrongGioHangMoi);
                _context.SaveChanges();

            }
            else
            {
                spNguoiDungDatTrongGioHang.SoLuong = spNguoiDungDatTrongGioHang.SoLuong + SoLuong;
                _context.GioHangs.Update(spNguoiDungDatTrongGioHang);
                _context.SaveChanges();
                
            }
            return RedirectToAction("GioHang");
        }

        public IActionResult GioHang()
        {
            if (!Functions.IsLogin())
            {
                TempData["msg"] = "Yêu cầu đăng nhập để sử dụng chức năng này.";
                return RedirectToAction("DangNhap", "TaiKhoan");
            }

            var gh = _context.view_GioHang_SanPhams.Where(db => db.IDNguoiDung == Functions._UserID).ToList();
            return View(gh);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult XoaKhoiGioHang(int id)
        {
            var spgh = _context.GioHangs.Find(id);
            _context.GioHangs.Remove(spgh);
            _context.SaveChanges();
            return RedirectToAction("GioHang");
        }
    }
}