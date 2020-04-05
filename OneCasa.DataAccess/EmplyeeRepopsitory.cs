using System;
using System.Collections.Generic;
using System.Data;
using OneCasa.Models.ViewModels;
using System.Data.SqlClient;
using System.Linq;

namespace OneCasa.DataAccess
{
    public class EmplyeeRepopsitory : BaseDataAccess
    {
        public EmplyeeRepopsitory(BaseDataAccess baseaccess)
            : base(baseaccess)
        {

        }
        public List<Employee> GetEmployeeData()
        {
            DBParameters.Clear();
            DataSet empList = ExecuteDataSet("sp_GetAllEmlpoyees");
            List<Employee> allemp = empList.Tables[0].AsEnumerable().Select(emp=>new Employee()
            {
                EmpId = emp.Field<int>("emp_id"),
                EmpName = emp.Field<string>("emp_name"),
                Manager = emp.Field<string>("Manager"),
                Department = emp.Field<string>("department"),
                Email = emp.Field<string>("Emailid"),
                DateOfBirth = emp.Field<DateTime>("DateOfBirth"),
                JoinDate = emp.Field<DateTime>("dateofjoin"),
                PhoneNumber=emp.Field<Int64>("PhoneNumber")
            }).ToList();
            return (allemp);
        }
    }
}