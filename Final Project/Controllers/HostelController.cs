using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Project.Content.Models;


namespace Final_Project.Controllers
{
    public class HostelController : Controller
    {
        static string constr = @"Data Source=UMERTECH\SQLEXPRESS; Initial Catalog=Hostel Suggestion System; Integrated Security=true";
        SqlConnection conn = new SqlConnection(constr);

        [HttpGet]
        public ActionResult HostelEntry()
        {
            if (Session["OwnerID"]  != null && Session["OwnerName"] != null)
            {
                return View();
            }
            else
            {
                return this.RedirectToAction("OwnerSignin", "Signin");
            }
        }

        [HttpPost]
        public ActionResult HostelEntry(Hostel obj)
        {
            int g, a, h;
            if (obj.geazer.Equals(true))
            {
                g = 1;
            }
            else
            {
                g = 0;
            }
            if (obj.heater.Equals(true))
            {
                h = 1;
            }
            else
            {
                h = 0;
            }
            if (obj.AC.Equals(true))
            {
                a = 1;
            }
            else
            {
                a = 0;
            }
            conn.Open();
            string query = "Insert Into Hostel Values('" + obj.h_id + "','" + obj.h_name + "','" + obj.h_address + "','" + obj.roomseats + "','" + g + "','" + h + "','" + a + "')";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            return View();
        }

        [HttpGet]
        public ActionResult ViewHostel()
        {
            if (Session["OwnerID"]  != null && Session["OwnerName"] != null)
            {
                List<Hostel> hostels = new List<Hostel>();
                conn.Open();
                string query = "select h_id, h_name, h_address from Hostel";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Hostel h = new Hostel();
                    h.h_id = sdr[0].ToString();
                    h.h_name = sdr[1].ToString();
                    h.h_address = sdr[2].ToString();

                    hostels.Add(h);
                }
                conn.Close();
                return View(hostels);
            }
            else
            {
                return this.RedirectToAction("OwnerSignin", "Signin");
            }
        }
        public Hostel HostelDetails(int id)
        {

            conn.Open();
            string quer = "Select *from Hostel Where h_id='" + id + "'";
            SqlCommand cmd = new SqlCommand(quer, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            Hostel a = new Hostel();
       
            while (sdr.Read())
            {
                a.h_id = sdr[0].ToString();
                a.h_name = sdr[1].ToString();
                a.h_address = sdr[2].ToString();
                a.roomseats = sdr[3].ToString();
                a.geazer = bool.Parse(sdr[4].ToString());
                a.heater = bool.Parse(sdr[5].ToString());
                a.AC = bool.Parse(sdr[6].ToString());
                
                
            }
            sdr.Close();
            conn.Close();


            return a;
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["OwnerID"] != null && Session["OwnerName"] != null)
            {
                Hostel a = new Hostel();
                a = HostelDetails(id);
                return View(a);
            }
            else
            {
                return this.RedirectToAction("OwnerSignin", "Signin");
            }
        }

        //Update

        [HttpPost]
        public ActionResult Edit(Hostel a)
        {
            conn.Open();
            string query = "update Hostel  set h_name='" + a.h_name + "', h_address='" + a.h_address + "', roomseats='" + a.roomseats + "', geazer='" + a.geazer + "', heater='" + a.heater + "', AC='" + a.AC + "' where h_id= '" + a.h_id + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("ViewHostel");
        }
        public ActionResult Select(string hid, string hname)
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




    }
    }