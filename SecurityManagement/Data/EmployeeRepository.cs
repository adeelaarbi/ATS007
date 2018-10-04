using SecurityManagement.Data.Entities;
using SecurityManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManagement.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.context.Employees.OrderBy(p => p.CreatedOn).ToList();
        }

        public IEnumerable<Employee> GetEmployeeByUser(ApplicationUser User)
        {
            return this.context.Employees.Where(p => p.User == User).ToList();
        }

        public bool SaveAll()
        {
            return this.context.SaveChanges() > 0;
        }
    }
}
