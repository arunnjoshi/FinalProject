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
            var employees = GetEmployeeData().Where(e=> new DateTime(DateTime.Now.Year,e.DateOfBirth.Month,e.DateOfBirth.Day) <= DateTime.Now.AddDays(10) && 
                                                    new DateTime(DateTime.Now.Year,e.DateOfBirth.Month,e.DateOfBirth.Day) >= DateTime.Now).OrderBy(e=>e.DateOfBirth.Month).ThenBy(e=>e.DateOfBirth.Day).ThenBy(e=>e.EmpName).ToList();
            return employees;
        }
        public List<Employee> PastBirthDays()
        {
            List<Employee> employees = new List<Employee>();

             // employee = GetEmployeeData()
             //    .Where(e => e.DateOfBirth <= DateTime.Now && e.DateOfBirth >= DateTime.Now.AddDays(-11)).OrderByDescending(e=>e.DateOfBirth).ToList();
            return employees;
        }

        public List<Employee> UpcomingAnniversary()
        {
           

            var employees=GetEmployeeData().Where(e=> new DateTime(DateTime.Now.Year,e.JoinDate.Month,e.JoinDate.Day) <= DateTime.Now.AddDays(10) && 
                                                  new DateTime(DateTime.Now.Year,e.JoinDate.Month,e.JoinDate.Day) >= DateTime.Now && e.JoinDate.Year < DateTime.Now.Year)
                                                  .OrderBy(e=>e.JoinDate.Month).ThenBy(e=>e.JoinDate.Day).ToList();

            return employees;
        }
        public List<Employee> PastAnniversary()
        {
            List<Employee> employees = new List<Employee>();

             // employees = GetEmployeeData()
             //    .Where(e =>  e.JoinDate >= DateTime.Now.AddDays(-11)).ToList();
               
           return employees;
        }

        public void AddEmployee(EmployeeAddress emp)
        {
            this.operation = () =>
            {
                EmplyeeRepopsitory access = new EmplyeeRepopsitory(this.Transaction);
                access.AddEmployee(emp);
            };
            this.Start(false);
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            this.operation = () =>
            {
                EmplyeeRepopsitory access = new EmplyeeRepopsitory(this.Transaction);
                departments = access.GetDepartments();
            };
            this.Start(false);
            return departments;
        }


        public EmployeeAddress GetEmployee(int id)
        {
            EmployeeAddress emp=new EmployeeAddress();
            this.operation = () =>
            {
                EmplyeeRepopsitory access = new EmplyeeRepopsitory(this.Transaction);
                emp = access.GetEmployee(id).FirstOrDefault();

            };
            this.Start(false);
            return emp;
        }

        public void EditEmployee(EmployeeAddress emp)
        {
            this.operation = () =>
            {
                EmplyeeRepopsitory access = new EmplyeeRepopsitory(this.Transaction);
                access.EditEmployee(emp);
            };
            this.Start(false);
        }


    }
}