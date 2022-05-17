 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegisterApp.Models;
namespace RegisterApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using(OurDbContext db= new OurDbContext())
            {
                return View(db.useraccount.ToList());
            }
            
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using(OurDbContext db= new OurDbContext())
                {
                    db.useraccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Name + " " + account.Surname + " successfully created";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using(OurDbContext db=new OurDbContext())
            {
                var usr = db.useraccount.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("Logged In");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is Wrong");
                }
                return View();
            }
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Homepage()
        {
            return View();
        }

    }
}