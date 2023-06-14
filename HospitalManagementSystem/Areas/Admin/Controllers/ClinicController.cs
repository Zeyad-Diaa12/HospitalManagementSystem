using cloudscribe.Pagination.Models;
using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClinicController : Controller
    {
        private IClinic _clinicInfo;
        public ClinicController(IClinic clinicInfo)
        {
            _clinicInfo = clinicInfo;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize=10)
        {
            return View(_clinicInfo.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = _clinicInfo.GetClinicById(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(ClinicViewModel vm) { 
            _clinicInfo.UpdateClinicInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ClinicViewModel vm)
        {
            _clinicInfo.AddClinicInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _clinicInfo.DeleteClinicInfo(id);
            return RedirectToAction("Index");
        }
    }
}
