using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ijpie.Web.Models
{
   
    public class WebAccess
    {
       
        public int ID { get; set; }
        public string UserName { get; set; }
       
        public string EndPoint { get; set; }
        public string AccessToken { get; set; }
        public string UserMail { get; set; }

        public string Password { get; set; }
        

    }
}