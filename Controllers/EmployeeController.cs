using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        public ActionResult SearchEmployees(Employee emp)
        {
            var EmployeeList = _context.Employees.Where(e =>
                e.FirstName.Contains(emp.FirstName) ||
                e.LastName.Contains(emp.LastName) ||
                e.PhoneNumber.Contains(emp.PhoneNumber) ||
                e.PostalCode.Contains(emp.PostalCode) ||
                e.EmailID.Contains(emp.EmailID) ||
                e.StateName.Contains(emp.StateName)
            ).ToList();
            return View(EmployeeList);
        }
    }
}