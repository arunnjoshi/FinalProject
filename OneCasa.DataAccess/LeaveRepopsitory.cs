using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OneCasa.Models.ViewModels;

namespace OneCasa.DataAccess
{
    public class LeaveRepopsitory : BaseDataAccess
    {
        public LeaveRepopsitory(BaseDataAccess baseaccess)
            : base(baseaccess)
        {
        }

        public List<PublicHolidays> GetPublicHolidays()
        {
            DBParameters.Clear();
            
            DateTime yearStart = new DateTime(DateTime.Now.Year,1,1);
            DateTime yearEnd = new DateTime(DateTime.Now.Year,12,31);
            AddParameter("@yearStart",yearStart);
            AddParameter("@yearEnd",yearEnd);
            
            DataSet deplist = ExecuteDataSet("sp_GetPublicHolidays");
            List<PublicHolidays> holidayses = deplist.Tables[0].AsEnumerable().Select(h=>new PublicHolidays()
            {
                Date = h.Field<DateTime>("date"),
                Name = h.Field<string>("name")
            }).OrderBy(h=>h.Date).ToList();
            return holidayses;
        }


        public void ApplyLeave(Leave leave)
        {
            DBParameters.Clear();

            AddParameter("@empId",leave.EmpId);
            AddParameter("@fromDate",leave.FromDate);
            AddParameter("@todate",leave.ToDate);
            AddParameter("@daycount",leave.ToDate.Day - leave.FromDate.Day);
            AddParameter("@comment",leave.Comment);
            AddParameter("@leaveType",leave.LeaveType);
            AddParameter("@leaveStatus","pending");
            AddParameter("@StartTime",DateTime.Now.TimeOfDay);
            AddParameter("@EndTime",DateTime.Now.TimeOfDay);

            ExecuteNonQuery("sp_ApplyLeave");
        }
    }
}