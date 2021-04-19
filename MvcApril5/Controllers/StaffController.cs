using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApril5.Models;

namespace MvcApril5.Controllers
{
    public class StaffController : Controller
    {
        MyDbContext context;
        public StaffController()
        {
            context = new MyDbContext();
        }
        // GET: Staff
        public ActionResult Index()
        {
            var stafflist = context.Staffs.ToList();
            return View(stafflist);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff model)
        {
            if(ModelState.IsValid)
            {

                context.Staffs.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }



        public ActionResult Edit(int id)
        {

            var staff = context.Staffs.FirstOrDefault(x => x.Id == id);
            if(staff==null)
                return RedirectToAction("Index");
            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(Staff model)
        {
            if (ModelState.IsValid)
            {
                var staff = context.Staffs.FirstOrDefault(x => x.Id == model.Id);

                staff.Name = model.Name;
                staff.Phone = model.Phone;
                staff.Age = model.Age;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {

            var staff = context.Staffs.FirstOrDefault(x => x.Id == id);
            if (staff == null)
                return RedirectToAction("Index");
            context.Staffs.Remove(staff);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}