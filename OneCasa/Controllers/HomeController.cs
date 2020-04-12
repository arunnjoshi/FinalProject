using System;
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
        public JsonResult GetUpcomingEvents()
        {
            var emp = _objEmployeeService.GetUpcomingEvents();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult GetPastEvents()
        {
            var emp=_objEmployeeService.GetPastEvents();
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
        [HttpGet]
        public ActionResult AddEmployee()
        {
            var dep = _objEmployeeService.GetDepartments();
            SelectList departments = new SelectList(dep,"depid","DepartmentName");
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeAddress emp)
        {
            try
            {
                _objEmployeeService.AddEmployee(emp);
                return RedirectToAction("GetEmployees","Home");
            }
            catch (Exception e)
            {
                return View();
            }
        }


        public ActionResult EditEmployee(int empid)
        {
            var dep = _objEmployeeService.GetDepartments();
            SelectList departments = new SelectList(dep,"depid","DepartmentName");
            ViewBag.Departments = departments;

            EmployeeAddress emp = _objEmployeeService.GetEmployee(empid);
            return View("EditEmployee",emp);
        }
        
        [HttpPost]
        public ActionResult EditEmployee(EmployeeAddress emp)
        {
            try
            {
                _objEmployeeService.EditEmployee(emp);
                return RedirectToAction("GetEmployees","Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("EditEmployee","Home",new {emp.EmpId});
            }
        }

    }
    
}