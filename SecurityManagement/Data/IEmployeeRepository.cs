using System.Collections.Generic;
using SecurityManagement.Data.Entities;
using SecurityManagement.Models;

namespace SecurityManagement.Data
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetEmployeeByUser(ApplicationUser User);
        bool SaveAll();
    }
}