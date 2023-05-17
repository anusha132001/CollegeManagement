using CollegeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeManagement.Controllers
{
    public class HomeController : Controller
    {
        CollegeDBEntities1 db = new CollegeDBEntities1();
        // GET
        public ActionResult Index()
        {
            using (CollegeDBEntities1 dbs = new CollegeDBEntities1())
            {
                return View(dbs.Admins.ToList());
            }
                
        }
        //Get
        public ActionResult Register()
        {
            return View();
        }
        //post
        [HttpPost]
        public ActionResult Register(Admin admin)
        {
            if(ModelState.IsValid)
            {
                using (CollegeDBEntities1 dbs= new CollegeDBEntities1())
                {
                    dbs.Admins.Add(admin);
                    dbs.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = admin.AdminName + " Successfuly Registered";
            }
            return View();
        }

        //Login 
        //Get
        public ActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            using (CollegeDBEntities1 dbs= new CollegeDBEntities1())
            {
                var usr1=dbs.Teachers.Where(u => u.Username == admin.Username && u.TeacherPassword == admin.AdminPassword).FirstOrDefault();
                var usr2 = dbs.Students.Where(u => u.Username == admin.Username && u.StudentPassword==admin.AdminPassword).FirstOrDefault();
                var usr=dbs.Admins.Where(u=>u.Username==admin.Username && u.AdminPassword==admin.AdminPassword).FirstOrDefault();
                if(usr!=null )
                {
                    Session["UserId"]=usr.AdminId.ToString();
                    Session["AdminName"] = usr.AdminName.ToString();
                    Session["UserName"]=admin.Username.ToString();
                    
                    return RedirectToAction("LogedinAdmin");
                }
               else  if (usr2 != null)
                {
                    Session["UserId"] = usr2.RollNumber.ToString();
                    Session["UserName"] = admin.Username.ToString();
                    Session["StudentName"] = usr2.StudentName.ToString();
                    return RedirectToAction("LogedinStudent");
                }
                else if (usr1 != null)
                {
                    Session["UserId"] = usr1.EmployeeId.ToString();
                    Session["UserName"] = admin.Username.ToString();
                    Session["TeacherName"] = usr1.FullName.ToString();
                    return RedirectToAction("LogedinTeacher");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password wrong");
                }
            }
            return View();
        }

        public ActionResult LogedinAdmin()
        {
            if( Session["UserId"] !=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogedinStudent()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogedinTeacher()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //Post
        //[HttpPost]
        //public ActionResult Index(Admin a1)
        //    {


        //    var obj1 = db.Admins.Where(a => a.Username.Equals(a1.Username) && a.AdminPassword.Equals(a1.AdminPassword));
        //    var obj2 = db.Teachers.Where(a => a.Username.Equals(a1.Username) && a.TeacherPassword.Equals(a1.AdminPassword));
        //    var obj3 = db.Students.Where(a => a.Username.Equals(a1.Username) && a.StudentPassword.Equals(a1.AdminPassword));
        //    if (obj1!=null)
        //    {
        //        Session["AdminId"] = a1.AdminId.ToString();
        //        Session["Username"]=a1.Username.ToString();
        //    }
        //    if (obj2 != null)
        //    {
        //        Session["TeacherId"] = a1.AdminId.ToString();
        //        Session["Username"] = a1.Username.ToString();
        //    }
        //    if (obj3 != null)
        //    {
        //        Session["TeacherId"] = a1.AdminId.ToString();
        //        Session["Username"] = a1.Username.ToString();
        //    }
        //    return RedirectToAction("Index","Loginpage");

        //    }
    }
    
}