using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OneCasa.DataAccess;
using OneCasa.Models.ViewModels;

namespace OneCasa.BusinessAccess
{
    public class EmployeeService : BaseBusinessAccess
    {
        // frequently used data
        private readonly List<Employee>  _employeesDate;
        public   EmployeeService()
        {
            _employeesDate = _GetEmployeeData();
        }

        private List<Employee> _GetEmployeeData()
        {
            List<Employee> listEmployeeData = new List<Employee>();
            this.operation = () =>
            {
                EmplyeeRepopsitory access = new EmplyeeRepopsitory(this.Transaction);
                listEmployeeData = access.GetEmployeeData();
            };
            this.Start(false);
            return listEmployeeData;
        }
        public List<Employee> GetEmployeeData()
        {
            // List<Employee> listEmployeeData = new List<Employee>();
            // this.operation = () =>
            // {
            //     EmplyeeRepopsitory access = new EmplyeeRepopsitory(this.Transaction);
            //     listEmployeeData = access.GetEmployeeData();
            // };
            // this.Start(false);
            return _employeesDate;
        }

        public List<Employee> UpcomigBirthDays()
        {
            List<Employee> employees = GetEmployeeData().Where(e=>
                e.DateOfBirth.Day >= DateTime.Now.Day && e.DateOfBirth.Day < DateTime.Now.Day+10 ).ToList();
            if (DateTime.Now.Date.Day>25)
            {
                List<Employee> newEmp = GetEmployeeData().Where(e => e.DateOfBirth.Month == DateTime.Now.Month+1 && e.DateOfBirth.Day <=5)
                    .ToList();
                employees.AddRange(newEmp);
            }
            return employees;
        }
        public List<Employee> PastBirthDays()
        {
            List<Employee> employees=new List<Employee>();
            if (DateTime.Now.Day <= 5)
            {
                List<Employee> newEmp = GetEmployeeData().Where(e => 
                    (e.DateOfBirth.Month == DateTime.Now.Month-1 && e.DateOfBirth.Day >= 25) 
                ).ToList();
                employees.AddRange(newEmp);
            }
            if (DateTime.Now.Day <= 10)
            {
                List<Employee> newEmp = GetEmployeeData().Where(e=>e.DateOfBirth.Month == DateTime .Now.Month && e.DateOfBirth.Day < DateTime.Now.Day).ToList();
                employees.AddRange(newEmp);
            }
            else
            {
              employees  = GetEmployeeData().Where(e
                    =>e.DateOfBirth.Day < DateTime.Now.Day && e.DateOfBirth.Day < DateTime.Now.Day-10).ToList();
            }
            return employees.OrderByDescending(x=>x.DateOfBirth).ToList();
        }

        public List<Employee> UpcomingAnniversary()
        {
            List<Employee> employees = GetEmployeeData().Where(e=>
                e.JoinDate.Day >= DateTime.Now.Day 
                                     && e.JoinDate.Day < (DateTime.Now.Day+10)
                                     && e.JoinDate.Year != DateTime.Now.Year
                ).ToList();
            if (DateTime.Now.Day>25)
            {
                List<Employee> newEmp = GetEmployeeData().Where(e=> 
                    e.JoinDate.Month == DateTime.Now.Month+1 
                                                        && e.JoinDate.Day <= 5
                    ).OrderBy(e=>e.JoinDate).ThenBy(e=>e.EmpName).ToList();
                employees.AddRange(newEmp);
            }
            return employees;
        }

        public List<Employee> PastAnniversary()
        {
            List<Employee> employees=new List<Employee>();
            if (DateTime.Now.Day <= 5)
            {
                List<Employee> newEmp = GetEmployeeData().Where(e => 
                    (e.JoinDate.Month == DateTime.Now.Month-1 && e.JoinDate.Day >= 25) 
                ).ToList();
                employees.AddRange(newEmp);
            }
            
            if (DateTime.Now.Day <= 10)
            {
                List<Employee> newEmp = GetEmployeeData().Where(e=>e.JoinDate.Month == DateTime .Now.Month && e.JoinDate.Day < DateTime.Now.Day).ToList();
                employees.AddRange(newEmp);
            }
            else
            {
                employees  = GetEmployeeData().Where(e
                    =>e.JoinDate.Day < DateTime.Now.Day && e.JoinDate.Day < DateTime.Now.Day-10).ToList();
            }
            return employees.OrderByDescending(e=>e.JoinDate).ThenBy(e=>e.EmpName).ToList();
        }

    }
}