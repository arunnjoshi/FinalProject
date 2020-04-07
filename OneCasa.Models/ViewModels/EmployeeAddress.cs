using System.ComponentModel;

namespace OneCasa.Models.ViewModels
{
    public class EmployeeAddress:Employee
    { 
        [DisplayName("Address")]
        public string Address { set; get; }
        [DisplayName("State")]
        public string State { get; set; }
        [DisplayName("PinCode")]
        public int PinCode { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
    }
}