using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Service;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        UserService _userService = new UserService();
        public ActionResult Index()
        {
            try
            {
                bool isLoggedIn = CheckLoggedIn();
                if (!isLoggedIn)
                {
                    Response.Redirect("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Profile()
        {
            ViewBag.Message = "My Profile.";

            return View();
        }

        /// <summary>
        /// Check whether a user is logged in or  not
        /// </summary>
        /// <returns></returns>
        public bool CheckLoggedIn()
        {
            if (Session["CurrentUser"] != null)
            {
                return true;
            }
            else
                return false;

        }
    }
}