using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApril5.Models;

namespace MvcApril5.Controllers
{
    public class StudentController : Controller
    {
        MyDbContext context;
        public StudentController()
        {
            context = new MyDbContext();
        }
        // GET: Student
        public ActionResult Index()
        {

            var studentlist = context.Students.ToList();
            return View(studentlist);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {

                context.Students.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {

            var student = context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return RedirectToAction("Index");
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                var student = context.Students.FirstOrDefault(x => x.Id == model.Id);

                student.Name = model.Name;
                student.Age = model.Age;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {

            var student = context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return RedirectToAction("Index");
            context.Students.Remove(student);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
