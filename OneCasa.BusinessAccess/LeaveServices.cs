using System.Collections.Generic;
using OneCasa.DataAccess;
using OneCasa.Models.ViewModels;

namespace OneCasa.BusinessAccess
{
    public class LeaveServices :BaseBusinessAccess
    {
        public List<PublicHolidays> GetPublicHolidays()
        {
            List<PublicHolidays> holidayses = new List<PublicHolidays>();
            this.operation = () =>
            {
                LeaveRepopsitory access = new LeaveRepopsitory(this.Transaction);
                holidayses = access.GetPublicHolidays();
            };
            this.Start(false);
            return holidayses;
        }
        
    }
}