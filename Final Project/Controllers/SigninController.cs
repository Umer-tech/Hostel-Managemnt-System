using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.Content.Models;

namespace Final_Project.Controllers
{
    public class SigninController : Controller
    {
        static string constr = @"Data Source=UMERTECH\SQLEXPRESS; Initial Catalog=Hostel Suggestion System; Integrated Security=true";
        SqlConnection con = new SqlConnection(constr);
        public ActionResult Signin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Signin(string btn)
        {
           

                return RedirectToAction("OwnerSignin");
            
        }
        [HttpGet]
        public ActionResult AlumniSignin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlumniSignin(Alumni s)
        {
            con.Open();
            string query = "select  a_email, a_name from Alumni where a_email='" + s.s_email + "' and a_password='" + s.s_password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                Session["AlumniID"] = sdr["a_email"].ToString();
                Session["AlumniName"] = sdr["a_name"].ToString();

            }
            con.Close();

            return RedirectToAction("AlumniHome");

        }
        [HttpGet]
        public ActionResult AlumniHome()
        {
            if (Session["AlumniID"] != null && Session["AlumniName"] != null)
            {
                return RedirectToAction("AlumniDashboard", "Alumni");
            }
            else
            {
                return this.RedirectToAction("AlumniSignup", "Signup");
            }
        }
        public ActionResult OwnerSignin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OwnerSignin(Owner o)
        {
            con.Open();
            string query = "select  o_id, o_name from Owner where o_email='" + o.o_email + "' and o_password='" + o.o_password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                Session["OwnerID"] = sdr["o_id"].ToString();
                Session["OwnerName"] = sdr["o_name"].ToString();

            }
            con.Close();

            return RedirectToAction("OwnerHome");

        }
        [HttpGet]
        public ActionResult OwnerHome()
        {
            if (Session["OwnerID"] != null && Session["OwnerName"] != null)
            {
                return RedirectToAction("OwnerDashboard", "Owner");
            }
            else
            {
                return this.RedirectToAction("OwnerSignup", "Signup");
            }
        }
        
        [HttpGet]
        public ActionResult HostelSpecs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HostelSpecs(Hostel h)
        {
            return View();
        }


    }
}