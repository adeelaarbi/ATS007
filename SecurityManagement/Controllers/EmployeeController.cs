using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityManagement.Data;
using SecurityManagement.Data.Entities;
using SecurityManagement.Models;
using SecurityManagement.Models.EmployeeViewModels;
using SecurityManagement.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecurityManagement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;

        public EmployeeController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, Services.IEmailSender emailSender, ILogger<EmployeeController> logger)
        {
            this.userManager = userManager;
            this.context = context;
            this.emailSender = emailSender;
            this.logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public IEmployeeRepository Employee { get; }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with provided ID'{this.userManager.GetUserId(User)}'.");
            }

            var users = from p in this.context.Users where p.parent_id == user.Id select p;
            ViewBag.Title = "Employee List";
            return View(users.ToList());
        }

        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            ApplicationUser user = await this.userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with provided ID'{this.userManager.GetUserId(User)}'.");
            }


            if (ModelState.IsValid)
            {
                var log_user = this.userManager.GetUserAsync(User);
                var employee = new Employee {
                    EmployeeCode = model.EmployeeCode,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    POBox = model.POBox,
                    ContactNo = model.ContactNo,
                    MobileNo = model.MobileNo,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    DateOfBirth = model.DateOfBirth,
                    PassportExpiryDate = model.PassportExpiryDate,
                    PassportIssueDate = model.PassportIssueDate,
                    PassportNo = model.PassportNo,
                    Nationality = model.Nationality,
                    Gender = model.Gender,
                    MaritalStatus = model.MaritalStatus,
                    PINCode = model.PINCode,
                    User = user
                };
                var errors = this.context.Employees.Add(employee);
                var result = this.context.SaveChanges();
                if (result == 1)
                {
                    this.logger.LogInformation("Employee created successfully.");

                    return RedirectToAction(nameof(EmployeeController.Index), "Employee");
                }
                return View(model);

            }

            return View(model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(AccountController.Login));
            }
        }

        #endregion
    }
}
