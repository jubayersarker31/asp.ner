using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcLoginAppDemo.Models
{
    public class CommentModel
    {
        public int ID { set; get; }
        public string PostId { get; set; }
        public int CommentText { get; set; }

        public string UserID { get; set; }

        public string DateTime { get; set; }

        public string UserName { get; set; }
        

    }
 
}