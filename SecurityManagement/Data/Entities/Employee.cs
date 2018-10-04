using SecurityManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityManagement.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAppUser { get; set; }
        public int PINCode { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string POBox { get; set; }
        public string MobileNo { get; set; }
        public string PassportNo { get; set; }
        public string ProfilePic { get; set; }
        public string PassportPlaceOfIssue { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ApplicationUser User { get; set; }
    }
}
