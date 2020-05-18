using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLoginAppDemo.Models
{
    public class PostModel
    {
        public int ID { set; get; }
        public string PostText { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }
        
        public string DateTime { get; set; }

        public List<CommentModel> CommentModelList { get; set; }
        
    }
 
}