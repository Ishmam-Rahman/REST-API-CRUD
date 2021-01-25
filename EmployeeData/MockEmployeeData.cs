using REST_API_CRUDE.Model;
using System;
using System.Collections.Generic;

namespace REST_API_CRUDE.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name = "Ishmam"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name = "Omi",
            },
        };

        public Employee AddEmployee( Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var exemp = GetEmployees(employee.Id);
            exemp.Name = employee.Name;
            return exemp;
        }

        public List<Employee> GetEmployees()
        {
           return employees;
        }

        public Employee GetEmployees(Guid id)
        {
            return employees.Find(x=>x.Id == id);
        } 
    }
}
