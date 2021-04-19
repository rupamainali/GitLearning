using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApril5.Models;

namespace MvcApril5.Controllers
{
    public class OrgController : Controller
    {
        MyDbContext context;
        public OrgController()
        {
            context = new MyDbContext();
        }
        // GET: Org
        public ActionResult Index()
        {

            string name = "John";
            ViewBag.Name = name;

            var orglist = context.Orgs.ToList();
            return View(orglist);

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Org model)
        {
            if (ModelState.IsValid)
            {

                context.Orgs.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {

            var org = context.Orgs.FirstOrDefault(x => x.Id == id);
            if (org == null)
                return RedirectToAction("Index");
            return View(org);
        }
        [HttpPost]
        public ActionResult Edit(Org model)
        {
            if (ModelState.IsValid)
            {
                var org = context.Orgs.FirstOrDefault(x => x.Id == model.Id);
                org.Id = model.Id;
                org.Name = model.Name;
                org.Address = model.Address;
                org.PhoneNumber = model.PhoneNumber;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {

            var org = context.Orgs.FirstOrDefault(x => x.Id == id);
            if (org == null)
                return RedirectToAction("Index");
            context.Orgs.Remove(org);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}