using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MvcLoginAppDemo.Models;
using System.Collections.Generic;

namespace MvcLoginAppDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                string conString = @"Data Source=DESKTOP-4VMML1C\JUBAYERSQL;initial Catalog=LoginDB;Integrated Security=True;";
                using (SqlConnection sqlCon = new SqlConnection(conString))
                {
                    sqlCon.Open();
                    string query = "SELECT COUNT(1) FROM tblUser WHERE username=@username AND password=@password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@username", objUser.UserName);
                    sqlCmd.Parameters.AddWithValue("@password", objUser.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            con.Open();
                            

                            SqlDataReader reader = null;
                            SqlConnection myConnection = new SqlConnection();
                            myConnection.ConnectionString = conString;

                            SqlCommand sqlCmd2 = new SqlCommand();
                            sqlCmd2.CommandType = CommandType.Text;

                            string query2 = "SELECT * FROM tblUser WHERE username=@username AND password=@password";

                            sqlCmd2.CommandText = "SELECT * FROM tblUser WHERE username=@username AND password=@password";
                            sqlCmd2.Parameters.AddWithValue("@username", objUser.UserName);
                            sqlCmd2.Parameters.AddWithValue("@password", objUser.Password);

                            sqlCmd2.Connection = myConnection;
                            myConnection.Open();
                            reader = sqlCmd2.ExecuteReader();
                            UserModel user = new UserModel();
                            List<UserModel> userList =new List<UserModel>();
                            while (reader.Read())
                            {
                                user = new UserModel();
                                Session["UserID"] = Convert.ToInt32(reader.GetValue(0));
                                user.UserId = Convert.ToInt32(reader.GetValue(0));
                                user.UserName = reader.GetValue(1).ToString();
                                user.Password = reader.GetValue(2).ToString();
                                
                                userList.Add(user);
                            }
                            myConnection.Close();


                            
                            Session["UserName"] = objUser.UserName;
                            return RedirectToAction("UserDashBoard");

                        }
                        
                    }
                    
                }



        
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
