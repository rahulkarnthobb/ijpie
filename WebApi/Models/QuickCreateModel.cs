namespace WebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    //public class QuickCreateModel : DbContext
    //{
    //    // Your context has been configured to use a 'QuickCreateModel' connection string from your application's 
    //    // configuration file (App.config or Web.config). By default, this connection string targets the 
    //    // 'WebApi.Models.QuickCreateModel' database on your LocalDb instance. 
    //    // 
    //    // If you wish to target a different database and/or database provider, modify the 'QuickCreateModel' 
    //    // connection string in the application configuration file.
    //    public QuickCreateModel()
    //        : base("name=QuickCreateModel")
    //    {
    //    }

    //    // Add a DbSet for each entity type that you want to include in your model. For more information 
    //    // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

       
    //}

    public class QuickCreate
    {
        public int ID { get; set; }
        public string OSLabel { get; set; }
        public string ServiceName { get; set; }

        public string Name { get; set; }

        public bool SendLink { get; set; }

        public string RecepientEmail { get; set; }
        public string VMPath { get; set; }

        public string Machine_Size { get; set; }


        public string OS { get; set; }

        public string ApplicationUserID { get; set; }
    }

    public class WebAccess
    {

        public int ID { get; set; }
        public string UserName { get; set; }

        public string EndPoint { get; set; }
        public string AccessToken { get; set; }
        public string UserMail { get; set; }

        public string Password { get; set; }
        public string ApplicationUserID { get; set; }


    }


}