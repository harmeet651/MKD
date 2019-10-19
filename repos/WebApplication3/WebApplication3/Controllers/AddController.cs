using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AddController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Add user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", "Add");
            }
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //getting count of customers to Assign it for new customer
            int count = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CountRows", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet d = new DataSet();
                da.Fill(d);
                con.Open();
                DataTable dt = new DataTable();
                dt = d.Tables["Table"];
                DataRow dr;
                dr = dt.Rows[0];
                count = (int)dr.ItemArray[0];
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insertData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = count + 1;
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 250).Value = user.message;
                cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 50).Value = user.firstName;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 50).Value = user.lastName;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = user.email;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("harmeetsingh2511@gmail.com", "enter your password here"),
                EnableSsl = true
            };
            client.Send("harmeetsingh2511@gmail.com", user.email, "Testing Code", user.message);
            Console.WriteLine("Sent");
            Console.ReadLine();
            return RedirectToAction("Index", "Home");
        }
    }
}