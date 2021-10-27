using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThuVien.Helper;
using ThuVien.ViewModels;

namespace ThuVien.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ISachService sachService;

        public HomeController(ISachService sachService)
        {
            this.sachService = sachService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var sachs = sachService.GetSachs(sortOrder, searchString, pageIndex, pageSize, out count);

            var vm = new IndexViewModel()
            {
                Sachs = new PaginatedList<SachDTO>(sachs, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
            };

            return View(vm);
        }
    }
}