using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using OneCasa.BusinessAccess;
using OneCasa.Models.ViewModels;

namespace OneCasa.Controllers
{
    public class HomeController : Controller
    {
        EmployeeService  _objEmployeeService;
        public HomeController()
        {
            _objEmployeeService = new EmployeeService();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetUpcomingBirthDays()
        {
            var emp = _objEmployeeService.UpcomigBirthDays().OrderBy(e=>e.DateOfBirth);
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetUpcomingAnniversary()
        {
            var emp = _objEmployeeService.UpcomingAnniversary();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetPastBirthDays()
        {
            var emp=_objEmployeeService.PastBirthDays();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetPastAnniversary()
        {
            var emp = _objEmployeeService.PastAnniversary();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            var emp = _objEmployeeService.GetEmployeeData();
            return View(emp);
        }
        
        [HttpGet]
        public JsonResult GetSearchEmployees()
        {
            var emp = _objEmployeeService.GetEmployeeData();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
    }
    
}