using Microsoft.AspNetCore.Mvc;
using doan.Models;

namespace doan.Components
{
    [ViewComponent(Name = "BaiVietGanDay")]
    public class BaiVietGanDayComponent : ViewComponent
    {
        private DataContext _context;

        public BaiVietGanDayComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bv = _context.BaiViets.Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", bv));
        }
    }
}
