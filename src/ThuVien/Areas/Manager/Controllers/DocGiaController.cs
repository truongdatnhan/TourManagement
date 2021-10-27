using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ThuVien.Areas.Manager.ViewModels;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.Controllers
{
    [Area("Manager")]
    //[Route("[Area]/[Controller]/[Action]")]
    //Này là authorize bt, chỉ cần đăng nhập là xem dc
    [Authorize]
    //Authorize Admin
    //[Authorize(Policy = "Admin")]
    //Authorize Thủ thư
    //[Authorize(Policy = "Librarian")]
    public class DocGiaController : Controller
    {
        private readonly IDocGiaService docGiaService;

        public DocGiaController(IDocGiaService docgiaService)
        {
            this.docGiaService = docgiaService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsdocgia = docGiaService.GetDSDocGia(sortOrder, searchString, pageIndex, pageSize, out count);
            var docGia = new DocGiaDTO();
            var docgiaVM = new DocGiaIndexVm()
            {
                DocGias = new PaginatedList<DocGiaDTO>(dsdocgia, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                docgia = docGia
            };
            ViewBag.DocGia = Convert.ToInt32(TempData["DocGia"]);
            return View(docgiaVM);
        }

        //Còn trong trường hợp muốn cụ thể ai có quyền mới làm dc
        //Nếu làm vậy thì những ai có thể vào xem dc index nhưng ko có quyền create member thì vẫn ko create dc
        [Authorize(Policy = "Create Member")]
        public IActionResult Create(DocGiaIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                docGiaService.CreateDocGia(vm.docgia);
                TempData["DocGia"] = 1;
                return RedirectToAction("Index");
            }
            TempData["DocGia"] = 5;
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [Authorize(Policy = "Delete Member")]
        public IActionResult Delete(DocGiaIndexVm vm)
        {
            docGiaService.DeleteDocGia(vm.docgia.MaDG);
            TempData["DocGia"] = 3;
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        [Authorize(Policy = "Edit Member")]
        public IActionResult Update(DocGiaIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                docGiaService.UpdateDocGia(vm.docgia);
                TempData["DocGia"] = 2;
                return RedirectToAction("Index");
            }
            TempData["DocGia"] = 4;
            return RedirectToAction("Index");
        }
    }
}