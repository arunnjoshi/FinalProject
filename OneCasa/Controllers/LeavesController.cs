using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OneCasa.BusinessAccess;
using OneCasa.Models.ViewModels;

namespace OneCasa.Controllers
{
    public class LeavesController : Controller
    {
        // GET
        private    LeaveServices _leaveServices;

        public LeavesController()
        {
            _leaveServices = new LeaveServices();
        }
        public ActionResult Index()
        {
            List<PublicHolidays> publicHolidayses =new List<PublicHolidays>();
            publicHolidayses = _leaveServices.GetPublicHolidays();
            ViewBag.PubluicHolidays = publicHolidayses;
            
            List<Leave> leaves = _leaveServices.GetApplyedLeaves();
            return View("Index",leaves);
        }
        
        [HttpGet]
        public ActionResult ApplyLeave()
        {
            return View("_ApplyLeave");
        }
        
        [HttpPost]
        public ActionResult ApplyLeave(Leave leave)
        {
            
            try
            {
                _leaveServices.ApplyLeave(leave);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("index");
            }
        }
    }
}