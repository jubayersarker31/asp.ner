using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MvcLoginAppDemo.Models;
using System.Collections.Generic;

namespace MvcLoginAppDemo.Controllers
{
    public class PostTextController : Controller
    {
        public ActionResult SavePost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserPostList(PostModel objPostModel)
        {
            if (ModelState.IsValid)
            {
                string conString = @"Data Source=DESKTOP-4VMML1C\JUBAYERSQL;initial Catalog=LoginDB;Integrated Security=True;";
                using (SqlConnection sqlCon = new SqlConnection(conString))
                {
                    sqlCon.Open();
                    DateTime now = DateTime.Now;
                    string query = @"INSERT INTO tblPostText (PostText, UserId, Date)
                    VALUES('"+ objPostModel.PostText + "', '" + Session["UserID"] + "', '" + now.Date.ToString() + "');";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@PostText", objPostModel.PostText);
                    sqlCmd.Parameters.AddWithValue("@UserId", Session["UserID"]);
                    
                    sqlCmd.Parameters.AddWithValue("@Date", now.Date.ToString());
                    SqlConnection myConnection2 = new SqlConnection();
                    myConnection2.ConnectionString = conString;
                    sqlCmd.Connection = myConnection2;
                    myConnection2.Open();
                    SqlDataReader reader2 = null;
                    reader2 = sqlCmd.ExecuteReader();
                    myConnection2.Close();
                    

                    //sqlCmd.ExecuteScalar();
                    PostModelList obPostModelList = new PostModelList();
                    if (true)
                    {
                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            //PostModelList obPostModelList = new PostModelList();
                            SqlDataReader reader = null;
                            SqlConnection myConnection = new SqlConnection();
                            myConnection.ConnectionString = conString;

                            SqlCommand sqlCmd2 = new SqlCommand();
                            sqlCmd2.CommandType = CommandType.Text;

                            
                            sqlCmd2.CommandText = "SELECT * FROM tblPostText";
                            
                            sqlCmd2.Connection = myConnection;
                            myConnection.Open();
                            reader = sqlCmd2.ExecuteReader();
                            PostModel obPostModel = new PostModel();
                            
                            obPostModelList.PostModels = new List<PostModel>();
                            while (reader.Read())
                            {
                                obPostModel = new PostModel();
                                obPostModel.ID = Convert.ToInt32(reader.GetValue(0));
                                obPostModel.PostText = reader.GetValue(1).ToString();
                                obPostModel.UserId = reader.GetValue(2).ToString(); ;
                                obPostModel.DateTime = reader.GetValue(3).ToString();
                                obPostModel.UserName = reader.GetValue(4).ToString();

                                obPostModelList.PostModels.Add(obPostModel);
                            }
                            if(obPostModelList.PostModels.Count > 0)
                            {
                                for(int i = 0; i< obPostModelList.PostModels.Count; i++)
                                {
                                    SqlConnection myConnection3 = new SqlConnection();
                                    myConnection3.ConnectionString = conString;

                                    myConnection3.ConnectionString = conString;

                                    sqlCmd2 = new SqlCommand();
                                    sqlCmd2.CommandType = CommandType.Text;


                                    sqlCmd2.CommandText = "SELECT * FROM tblComment2 where  PostId=@PostId";
                                    //string postId = obPostModelList.PostModels[i].ID.ToString();
                                    sqlCmd2.Parameters.AddWithValue("@PostId", obPostModelList.PostModels[i].ID.ToString());
                                    
                                    sqlCmd2.Connection = myConnection3;
                                    myConnection3.Open();
                                    reader = sqlCmd2.ExecuteReader();
                                    CommentModel obCommentModel = new CommentModel();
                                    obPostModelList.PostModels[i].CommentModelList = new List<CommentModel>();
                                    while (reader.Read())
                                    {
                                        obCommentModel = new CommentModel();
                                        obCommentModel.ID = Convert.ToInt32(reader.GetValue(0));
                                        obCommentModel.PostId = Convert.ToInt32(reader.GetValue(0)).ToString();
                                        obCommentModel.CommentText = Convert.ToInt32(reader.GetValue(2));
                                        obCommentModel.UserID = reader.GetValue(3).ToString();
                                        obCommentModel.DateTime = reader.GetValue(4).ToString();
                                        obCommentModel.UserName = reader.GetValue(4).ToString();


                                        obPostModelList.PostModels[i].CommentModelList.Add(obCommentModel);
                                    }
                                    myConnection3.Close();
                                }
                            }
                            myConnection.Close();
                            





                            ViewBag.message = "Text Posted";
                            return View("UserPostList", obPostModelList);
                            //return RedirectToAction("UserPostList");
                        }
                        
                    }
                    
                }
            }
            return View(objPostModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserPostList()
        {
            
                string conString = @"Data Source=DESKTOP-4VMML1C\JUBAYERSQL;initial Catalog=LoginDB;Integrated Security=True;";
                using (SqlConnection sqlCon = new SqlConnection(conString))
                {
                    sqlCon.Open();
                    
                   
                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            //PostModelList obPostModelList = new PostModelList();
                            SqlDataReader reader = null;

                            SqlConnection myConnection = new SqlConnection();
                            myConnection.ConnectionString = conString;

                            SqlCommand sqlCmd2 = new SqlCommand();
                            sqlCmd2.CommandType = CommandType.Text;


                            sqlCmd2.CommandText = "SELECT * FROM tblPostText";

                            sqlCmd2.Connection = myConnection;
                            myConnection.Open();
                            reader = sqlCmd2.ExecuteReader();
                            PostModel obPostModel = new PostModel();
                             PostModelList obPostModelList = new PostModelList();
                            obPostModelList.PostModels = new List<PostModel>();
                            while (reader.Read())
                            {
                                obPostModel = new PostModel();
                                obPostModel.ID = Convert.ToInt32(reader.GetValue(0));
                                obPostModel.PostText = reader.GetValue(1).ToString();
                                obPostModel.UserId = reader.GetValue(2).ToString(); ;
                                obPostModel.DateTime = reader.GetValue(3).ToString();
                                obPostModel.UserName = reader.GetValue(4).ToString();

                                obPostModelList.PostModels.Add(obPostModel);
                            }
                            if (obPostModelList.PostModels.Count > 0)
                            {
                                for (int i = 0; i < obPostModelList.PostModels.Count; i++)
                                {

                                    SqlConnection myConnection3 = new SqlConnection();
                                    myConnection3.ConnectionString = conString;

                                    myConnection3.ConnectionString = conString;

                                    sqlCmd2 = new SqlCommand();
                                    sqlCmd2.CommandType = CommandType.Text;


                                    sqlCmd2.CommandText = "SELECT * FROM tblComment2 where  PostId=@PostId";
                                    //string postId = obPostModelList.PostModels[i].ID.ToString();
                                    sqlCmd2.Parameters.AddWithValue("@PostId", obPostModelList.PostModels[i].ID.ToString());

                                    sqlCmd2.Connection = myConnection3;
                                    myConnection3.Open();
                                    reader = sqlCmd2.ExecuteReader();
                                    CommentModel obCommentModel = new CommentModel();
                                    obPostModelList.PostModels[i].CommentModelList = new List<CommentModel>();
                                    while (reader.Read())
                                    {
                                        obCommentModel = new CommentModel();
                                        obCommentModel.ID = Convert.ToInt32(reader.GetValue(0));
                                        obCommentModel.PostId = Convert.ToInt32(reader.GetValue(0)).ToString();
                                        obCommentModel.CommentText = Convert.ToInt32(reader.GetValue(2));
                                        obCommentModel.UserID = reader.GetValue(3).ToString();
                                        obCommentModel.DateTime = reader.GetValue(4).ToString();
                                        obCommentModel.UserName = reader.GetValue(4).ToString();


                                        obPostModelList.PostModels[i].CommentModelList.Add(obCommentModel);
                                    }
                                       myConnection3.Close();
                                }
                            }
                            myConnection.Close();





                            ViewBag.message = "Text Posted";
                            return View("UserPostList", obPostModelList);
                            //return RedirectToAction("UserPostList");
                        }

                    

                }
            
          
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
