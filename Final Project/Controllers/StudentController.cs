using Final_Project.Content.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class StudentController : Controller
    {
        static string constr = @"Data Source=UMERTECH\SQLEXPRESS; Initial Catalog=Hostel Suggestion System; Integrated Security=true";
        SqlConnection conn = new SqlConnection(constr);
        public ActionResult StudentEntry()
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
        public ActionResult StudentEntry(Student p)
        {

            conn.Open();

            string query = "Insert Into Studentt Values('" + p.s_id + "','" + p.s_name + "','" + p.s_edu + "','" + p.s_uni + "')";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();

            conn.Close();
            return View();
        }
        [HttpGet]
        public ActionResult StudentsData()
        {
            if (Session["OwnerID"] != null && Session["OwnerName"] != null)
            {
                List<Student> student = new List<Student>();
                conn.Open();

                string query = "select * from Studentt";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Student s = new Student();
                    s.s_id= sdr[0].ToString();
                    s.s_name = sdr[1].ToString();
                    s.s_edu = sdr[2].ToString();
                    s.s_uni = sdr[3].ToString();

                    student.Add(s);
                }
                conn.Close();
                return View(student);
            }
            else
            {
                return this.RedirectToAction("OwnerSignin", "Signin");
            }

        }

    }
}