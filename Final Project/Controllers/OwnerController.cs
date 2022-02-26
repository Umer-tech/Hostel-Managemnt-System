using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class OwnerController : Controller
    {
        static string constr = @"Data Source=UMERTECH\SQLEXPRESS; Initial Catalog=Hostel Suggestion System; Integrated Security=true";
        SqlConnection con = new SqlConnection(constr);

        [HttpGet]
        public ActionResult OwnerDashboard()
        {
            if (Session["OwnerID"] != null && Session["OwnerName"] != null)
            {
                return View();
            }
            else
            {
                return this.RedirectToAction("OwnerSignin", "Signin");
            }
        }

        [HttpPost]
        public ActionResult OwnerDashboard(string btn)
        {
            if (btn == "View Hostels")
                return this.RedirectToAction("ViewHostel", "Hostel");
            else if (btn == "Add Hostel")
                return this.RedirectToAction("HostelEntry", "Hostel");
            else if (btn == "View Students")
                return this.RedirectToAction("StudentsData", "Student");
            else
                return this.RedirectToAction("StudentEntry", "Student");

        }
    }
}