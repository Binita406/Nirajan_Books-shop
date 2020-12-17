using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nirajan_Books_shop;

namespace Nirajan_Books_shop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user usr)
        {

            //get username password form user)
            //check it with database user table

            Nirajan_Book_shopEntities3 dbObject = new Nirajan_Book_shopEntities3();
            var checkUser = dbObject.users.Where(l => l.u_name.Equals(usr.u_name ) && l.u_password.Equals(usr.u_password)).FirstOrDefault();
            if (checkUser != null)
            {
                var loggeduser = dbObject.users.Where(l => l.u_name.Equals(usr.u_name)).FirstOrDefault();
                Session["u_name"] = loggeduser.u_name.ToString();
                Session["u_id"] = loggeduser.u_id.ToString();
                Session["u_type"] = loggeduser.u_type.ToString();
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";
                return View();
            }

        }
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}
