using Final_Project.Content.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class OHSController : Controller
    {
        static string constr = @"Data Source=UMERTECH\SQLEXPRESS; Initial Catalog=Hostel Suggestion System; Integrated Security=true";
        SqlConnection conn = new SqlConnection(constr);

        [HttpGet]
        public ActionResult StudentEntry( string OwnerID, int h_id, string hname)
        {
            if (Session["OwnerID"] != null && Session["OwnerName"] != null)
            {
                Session["Owner_id"] = OwnerID;
                Session["h_Id"] = h_id;
                ViewBag.studentsdata = getStudents();
                return View();
            }
           
            else
            {
                return this.RedirectToAction("OwnerSignup", "Signup");
            }
        }

        [HttpPost]
        public ActionResult StudentEntry(OHS sp)
        {
            if (Session["OwnerID"] != null && Session["OwnerName"] != null)
            {
                string Ownerid = Session["OwnerID"].ToString();
                string h_id = Session["h_id"].ToString();
                var fname = sp.imageFile.FileName;

                var allext = new[] { ".jpg", ".png", ".bmp", ".gif" };
                var fileext = Path.GetExtension(fname);
                if (allext.Contains(fileext))
                {
                    var folderpath = Path.Combine(Server.MapPath("~/Images"), fname);
                    sp.imageFile.SaveAs(folderpath);
                    string dbpath = "/Images/" + fname;
                    string que = "insert into OHS values('" + Ownerid + "','" + h_id + "','" + sp.s_id + "','" + dbpath + "')";
                    InsertMethod(que);
                }

                else
                {
                    ViewBag.error = "Uplode Image File Name";

                }
                ViewBag.studentsdata = getStudents();
                return View();
            }
            else
            {
                return this.RedirectToAction("OwnerSignup", "Signup");
            }
        }
        private void InsertMethod(string que)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(que, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private List<SelectListItem> getStudents()
        {
            List<SelectListItem> slist = new List<SelectListItem>();
            conn.Open();
            string qu = "select * from Studentt";
            SqlCommand cmd = new SqlCommand(qu, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                slist.Add(new SelectListItem { Value = sdr["s_id"].ToString(), Text = sdr["s_name"].ToString() });
            }
            sdr.Close();
            conn.Close();
            return slist;
        }
        [HttpGet]
        public ActionResult ViewHostelStudents()
        {
            if (Session["OwnerID"] != null && Session["OwnerName"] != null)
            {
                List<OHS> plist = new List<OHS>();
                conn.Open();
                string qu = "select s.s_id,s.s_name, o.img from Studentt s inner join OHS o on s.s_id=o.s_id where o_id='" + Request.QueryString["OwnerId"] + "' and h_id='" + Request.QueryString["Hostelid"] + "'";
                SqlCommand cmd = new SqlCommand(qu, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    OHS s = new OHS();
                    s.o_id = Session["OwnerID"].ToString();
                    s.h_id = Request.QueryString["Hostelid"];
                    s.s_id = sdr["s_id"].ToString();
                    s.imagepath = sdr["img"].ToString();
                    s.Studname = sdr["s_name"].ToString();
                    plist.Add(s);
                }
                sdr.Close();
                conn.Close();
                return View(plist);
            }
            else
            {
                return this.RedirectToAction("OwnerSignup", "Signup");
            }
        }
    }
}