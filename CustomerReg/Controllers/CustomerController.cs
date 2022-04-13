using CustomerReg.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerReg.Controllers
{
    public class CustomerController : Controller
    {

        public ApplicationDbContext dbContext { get; private set; }
        public CustomerController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult ShowAllCus()
        {
            var customers = dbContext.Customers.ToList();
            return View(customers);
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            dbContext.Add(customer);
            dbContext.SaveChanges();
            
            return RedirectToAction("ShowAllCus");
        }
        public JsonResult GetCountries()
        {
            var countries = dbContext.Countries.ToList();
            return Json(countries);
        }

        public JsonResult GetStates(int id)
        {
            var states = dbContext.States.Where(e => e.CountId == id).ToList();
            return Json(states);
        }
        public JsonResult GetCities(int id)
        {
            var cities = dbContext.Cities.Where(e => e.StateId == id).ToList();
            return Json(cities);
        }
    }
}
