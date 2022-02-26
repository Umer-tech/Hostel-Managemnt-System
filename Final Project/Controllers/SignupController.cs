using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Final_Project.Content.Models;
namespace Final_Project.Controllers
{
    public class SignupController : Controller
    {
        static string constr = @"Data Source=UMERTECH\SQLEXPRESS; Initial Catalog=Hostel Suggestion System; Integrated Security=true";
        SqlConnection con = new SqlConnection(constr);


        public ActionResult Signup()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Signup(string btn)
        {
            if (btn == "A Owner")
            {

                return RedirectToAction("OwnerSignup");
            }
            else
            {
                return RedirectToAction("AlumniSignup");
            }
        }
        [HttpGet]
        public ActionResult AlumniSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlumniSignup(Alumni s)
        {
            con.Open();
            var s_id = s.s_email.Split('@')[0];
            string query = "insert into Alumni values('" + s_id + "','" + s.s_name + "','" + s.s_email + "','" + s.s_password + "','" + s.s_address + "','" + s.s_phone + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();

            con.Close();
            return this.RedirectToAction("AlumniSignin", "Signin");

        }
        // GET: Owner
        [HttpGet]
        public ActionResult OwnerSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OwnerSignup(Owner o)
        {
            con.Open(); 
            var o_id = o.o_email.Split('@')[0];
            string query = "insert into Owner values ('" + o_id + "','" + o.o_name + "','" + o.o_email + "','" + o.o_password + "','" + o.o_address + "','" + o.o_phone + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();
            return this.RedirectToAction("OwnerSignin", "Signin");

        }
    }
}