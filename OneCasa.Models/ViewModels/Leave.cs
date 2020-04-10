using System;
using System.ComponentModel.DataAnnotations;

namespace OneCasa.Models.ViewModels
{
    public class Leave
    {
        [Required]
        public int EmpId { get; set; }
        
        
        
        
        public string EmpName { get; set; }
        
        
        

        public string Department { get; set; }
        
        
        
        
        public string LeaveStatus { get; set; }
        
        
        

        public string Status { get; set; }
        
        
        
        
        [Required]
        public string LeaveType { get; set; }
        
        
        [Required]
        public DateTime FromDate { get; set; }
        
        
        [Required]
        public DateTime ToDate { get; set; }


        [Required]
        [MinLength(10 ,ErrorMessage = "Min Letters 10"),MaxLength(100,ErrorMessage = "Max Letters 100")]
        public string Comment { get; set; }
    }
}