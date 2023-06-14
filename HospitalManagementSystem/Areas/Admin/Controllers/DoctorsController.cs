using Hospital.Services;
using Hospital.Utilites;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DoctorsController : Controller
    {
        private IDoctor _doctorInfo;
        public DoctorsController(IDoctor doctorInfo)
        {
            _doctorInfo = doctorInfo;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctorInfo.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = _doctorInfo.GetdoctorById(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(DoctorViewModel vm)
        {
            _doctorInfo.UpdateDoctorInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DoctorViewModel vm)
        {
            _doctorInfo.AddDoctorInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _doctorInfo.DeleteDoctorInfo(id);
            return RedirectToAction("Index");
        }
    }
}
