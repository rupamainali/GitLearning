using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApril5.Models;

namespace MvcApril5.Controllers
{
    public class EmployeeController : Controller
    {

        MyDbContext context;
        public EmployeeController()
        {
            context = new MyDbContext();
        }
        // GET: Employee
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {

            var employeelist = context.Employees.ToList();
            return View(employeelist);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {

                context.Employees.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {

            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
                return RedirectToAction("Index");
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                var employee = context.Employees.FirstOrDefault(x => x.Id == model.Id);
                employee.Id = model.Id;
                employee.Name = model.Name;
                employee.City = model.City;
                employee.State = model.State;
                employee.ContactNumber = model.ContactNumber;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {

            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
                return RedirectToAction("Index");
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

    
    
