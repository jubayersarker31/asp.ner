using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLoginAppDemo.Models
{
    public class UserModel
    {
        public int UserId { set; get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
    public class UserModelList
    {
        public List<UserModel> UserModels { set; get; }
        
    }
}