using Microsoft.AspNetCore.Mvc;
using doan.Models;

namespace doan.Components
{
    [ViewComponent(Name = "SanPhamBanChay")]
    public class SanPhamBanChayiComponent : ViewComponent
    {
        private DataContext _context;

        public SanPhamBanChayiComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sp=_context.SanPhams.OrderByDescending(sp => sp.ID).Take(7).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", sp));
        }
    }
}
