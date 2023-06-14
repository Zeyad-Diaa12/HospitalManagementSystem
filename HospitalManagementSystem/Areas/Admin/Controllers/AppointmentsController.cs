using Hospital.Services;
using Hospital.Utilites;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppointmentsController : Controller
    {
        private IAppointment _appInfo;
        public AppointmentsController(IAppointment appInfo)
        {
            _appInfo = appInfo;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_appInfo.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var vm = _appInfo.GetAppointmentById(id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(AppointmentViewModel vm)
        {
            _appInfo.UpdateAppointmentInfo(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AppointmentViewModel vm)
        {
            _appInfo.AddAppointmentInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _appInfo.DeleteAppointmentInfo(id);
            return RedirectToAction("Index");
        }
    }
}
