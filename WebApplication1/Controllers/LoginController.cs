using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewData["DontShowLogin"] = true;
            return View();
        }
        /*public ActionResult SearchByEmail()
        {
            return View();
        }*/
        public ActionResult SearchByEmail(string command)
        {
            if(command == null)
            {
                return View();
            }
            else
            {
                SqlDataReader dr = null;
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170412081154.mdf;Initial Catalog=aspnet-WebApplication1-20170412081154;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(command, conn);

                Package P = new Package();
                P.Id = new List<int>();
                P.Firstname = new List<string>();
                P.Lastname = new List<string>();
                P.Email = new List<string>();
                try
                {
                    // open the connection
                    conn.Open();

                    // 1. get an instance of the SqlDataReader
                    dr = cmd.ExecuteReader();

                    // 2. print necessary columns of each record
                    while (dr.Read())
                    {
                        // get the results of each column
                        int id = (int)dr["Id"];
                        string Firstname = (string)dr["Firstname"];
                        string Lastname = (string)dr["Lastname"];
                        string Email = (string)dr["Email"];

                        P.Id.Add(id);
                        P.Firstname.Add(Firstname);
                        P.Lastname.Add(Lastname);
                        P.Email.Add(Email);
                    }
                }
                finally
                {
                    // 3. close the reader
                    if (dr != null)
                    {
                        dr.Close();
                    }

                    // close the connection
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
                ViewData["show"] = true;
                return View(P);
            }
            
        }

        public ActionResult partial_test()
        {
            return View();
        }
        public ActionResult partial_text(string table,string value)
        {
            string command = "select * from Logins where ";
            command += table;
            command += "='";
            command += value;
            command += "'";

            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170412081154.mdf;Initial Catalog=aspnet-WebApplication1-20170412081154;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(command, conn);

            Package P = new Package();
            P.Id = new List<int>();
            P.Firstname = new List<string>();
            P.Lastname = new List<string>();
            P.Email = new List<string>();
            try
            {
                // open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                dr = cmd.ExecuteReader();

                // 2. print necessary columns of each record
                while (dr.Read())
                {
                    // get the results of each column
                    int id = (int)dr["Id"];
                    string Firstname = (string)dr["Firstname"];
                    string Lastname = (string)dr["Lastname"];
                    string Email = (string)dr["Email"];

                    P.Id.Add(id);
                    P.Firstname.Add(Firstname);
                    P.Lastname.Add(Lastname);
                    P.Email.Add(Email);
                }
            }
            finally
            {
                // 3. close the reader
                if (dr != null)
                {
                    dr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }



            return PartialView("_partialdata",P);
        }
        public ActionResult Forget_ID()
        {
            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170412081154.mdf;Initial Catalog=aspnet-WebApplication1-20170412081154;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Logins", conn);

            Package P = new Package();
            P.Id = new List<int>();
            P.Firstname = new List<string>();
            P.Lastname = new List<string>();
            P.Email = new List<string>();
            try
            {
                // open the connection
                conn.Open();

                // 1. get an instance of the SqlDataReader
                dr = cmd.ExecuteReader();

                // 2. print necessary columns of each record
                while (dr.Read())
                {
                    // get the results of each column
                    int id = (int)dr["Id"];
                    string Firstname = (string)dr["Firstname"];
                    string Lastname = (string)dr["Lastname"];
                    string Email = (string)dr["Email"];

                    P.Id.Add(id);
                    P.Firstname.Add(Firstname);
                    P.Lastname.Add(Lastname);
                    P.Email.Add(Email);
                }
            }
            finally
            {
                // 3. close the reader
                if (dr != null)
                {
                    dr.Close();
                }

                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }


            return View(P);
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20170412081154.mdf;Initial Catalog=aspnet-WebApplication1-20170412081154;Integrated Security=True");
               

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Logins(id, Firstname,Lastname,Email) values('" + collection["ID"] + "','" + collection["Firstname"] + "','" + collection["Lastname"] + "','" + collection["Email"] + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                //
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // POST: Login/get_email
        [HttpPost]
        public ActionResult Get_email(FormCollection collection)
        {
            /*****string******/
            string command = "select * from Logins where Email='";
            command += collection["Email"];
            command += "'";
            ViewData["show"] = true;
            /*****************/
            return RedirectToAction("SearchByEmail", new { command });//,P
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
