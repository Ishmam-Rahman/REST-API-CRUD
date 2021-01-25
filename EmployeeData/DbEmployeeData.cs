
using REST_API_CRUDE.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST_API_CRUDE.EmployeeData
{
    public class DbEmployeeData : IEmployeeData
    {
        private APIEmployeeDB _APIEmployeeDB;

        public DbEmployeeData(APIEmployeeDB aPIEmployeeDB)
        {
            _APIEmployeeDB = aPIEmployeeDB;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _APIEmployeeDB.Employee.Add(employee);
            _APIEmployeeDB.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _APIEmployeeDB.Employee.Remove(employee);
            _APIEmployeeDB.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var exemp = _APIEmployeeDB.Employee.Find(employee.Id);
            exemp.Name = employee.Name;
            _APIEmployeeDB.Employee.Update(exemp);
            _APIEmployeeDB.SaveChanges();
            return employee;
        }

        public List<Employee> GetEmployees()
        {
           return _APIEmployeeDB.Employee.ToList();
        }

        public Employee GetEmployees(Guid id)
        {
             return _APIEmployeeDB.Employee.Find(id);
        }
    }
}
