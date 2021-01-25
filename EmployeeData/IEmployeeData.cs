using REST_API_CRUDE.Model;
using System;
using System.Collections.Generic;


namespace REST_API_CRUDE.EmployeeData
{
    public interface IEmployeeData
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployees(Guid Id);
        public Employee AddEmployee(Employee employee);
        public Employee EditEmployee(Employee employee);
        public void DeleteEmployee(Employee employee);
    }
}
