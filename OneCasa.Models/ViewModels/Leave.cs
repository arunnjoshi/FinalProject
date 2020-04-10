using System;

namespace OneCasa.Models.ViewModels
{
    public class Leave
    {
        public int EmpId { get; set; }
        
        public string EmpName { get; set; }

        public string Department { get; set; }

        public string LeaveType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Comment { get; set; }
    }
}