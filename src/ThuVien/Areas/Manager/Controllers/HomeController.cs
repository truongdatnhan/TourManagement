using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ThuVien.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ISachRepository sachRepository;
        private readonly ITheLoaiRepository theLoaiRepository;
        private readonly ITacGiaRepository tacGiaRepository;
        private readonly INhaXuatBanRepository nhaXuatBanRepository;
        private readonly IDocGiaRepository docGiaRepository;

        public HomeController(ISachRepository sachRepository, ITheLoaiRepository theLoaiRepository,
            ITacGiaRepository tacGiaRepository, INhaXuatBanRepository nhaXuatBanRepository,
            IDocGiaRepository docGiaRepository)
        {
            this.sachRepository = sachRepository;
            this.theLoaiRepository = theLoaiRepository;
            this.tacGiaRepository = tacGiaRepository;
            this.nhaXuatBanRepository = nhaXuatBanRepository;
            this.docGiaRepository = docGiaRepository;
        }

        public IActionResult Index()
        {
            ViewBag.countsach = sachRepository.CountSach();
            ViewBag.counttheloai = theLoaiRepository.CountTheLoai();
            ViewBag.counttacgia = tacGiaRepository.CountTacGia();
            ViewBag.countnxb = nhaXuatBanRepository.CountNXB();
            ViewBag.countdocgia = docGiaRepository.CountDocGia();
            return View();
        }
    }
}