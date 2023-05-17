using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagement.Controllers
{
    public class AdminController : Controller
    {
        CollegeDBEntities1 db = new CollegeDBEntities1();
        // GET: Admin
        public ActionResult RegisterTeacher()
        {
            return View();
        }

        //Post 
        [HttpPost]
        public ActionResult RegisterTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                using (CollegeDBEntities1 dbs = new CollegeDBEntities1())
                {
                    dbs.Teachers.Add(teacher);
                    dbs.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = teacher.FullName + " Successfuly Registered";
            }
            return View();
        }
        //GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
