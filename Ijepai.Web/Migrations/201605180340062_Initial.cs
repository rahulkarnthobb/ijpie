namespace ijpie.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Labs", t => t.LabID, cascadeDelete: true)
                .Index(t => t.LabID);
            
            CreateTable(
                "dbo.Labs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time_Zone = c.String(),
                        Start_Time = c.DateTime(nullable: false),
                        End_Time = c.DateTime(nullable: false),
                        Status = c.String(),
                        HKey = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                        LabConfigurationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Email_Address = c.String(),
                        Credit_Card_Number = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.LabSoftwareCustoms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Software_Path = c.String(),
                        LabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Labs", t => t.LabID, cascadeDelete: true)
                .Index(t => t.LabID);
            
            CreateTable(
                "dbo.LabConfigurations",
                c => new
                    {
                        LabID = c.Int(nullable: false),
                        VM_Count = c.Int(),
                        VM_Type = c.String(),
                        Hard_Disk = c.Double(nullable: false),
                        Machine_Size = c.String(),
                        OS = c.String(),
                        Networked = c.String(),
                    })
                .PrimaryKey(t => t.LabID)
                .ForeignKey("dbo.Labs", t => t.LabID)
                .Index(t => t.LabID);
            
            CreateTable(
                "dbo.LabParticipants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email_Address = c.String(),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Role = c.String(),
                        VM_ID = c.String(),
                        LabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Labs", t => t.LabID, cascadeDelete: true)
                .Index(t => t.LabID);
            
            CreateTable(
                "dbo.LabSoftwarePredefineds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoftwareID = c.Int(nullable: false),
                        LabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Labs", t => t.LabID, cascadeDelete: true)
                .ForeignKey("dbo.Softwares", t => t.SoftwareID, cascadeDelete: true)
                .Index(t => t.SoftwareID)
                .Index(t => t.LabID);
            
            CreateTable(
                "dbo.Softwares",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Software_Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LabCreates",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Time_Zone = c.String(),
                        Start_Time = c.DateTime(nullable: false),
                        End_Time = c.DateTime(nullable: false),
                        VM_Count = c.Int(nullable: false),
                        Networked = c.String(),
                        Machine_Size = c.String(nullable: false),
                        OS = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Lab_Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Role = c.String(),
                        LabCreate_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Lab_Id)
                .ForeignKey("dbo.LabCreates", t => t.LabCreate_Name)
                .Index(t => t.LabCreate_Name);
            
            CreateTable(
                "dbo.PredefinedSoftwares",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LabCreates", t => t.Name)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.LabDataDisks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataDisk_Path = c.String(),
                        LabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Labs", t => t.LabID, cascadeDelete: true)
                .Index(t => t.LabID);
            
            CreateTable(
                "dbo.LabFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        File_Path = c.String(),
                        LabID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Labs", t => t.LabID, cascadeDelete: true)
                .Index(t => t.LabID);
            
            CreateTable(
                "dbo.LabVMs",
                c => new
                    {
                        Lab_ID = c.Int(nullable: false),
                        VM_Path = c.String(),
                    })
                .PrimaryKey(t => t.Lab_ID)
                .ForeignKey("dbo.Labs", t => t.Lab_ID)
                .Index(t => t.Lab_ID);
            
            CreateTable(
                "dbo.QuickCreateSoftwaresCustoms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuickCreateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuickCreateModels", t => t.QuickCreateID, cascadeDelete: true)
                .Index(t => t.QuickCreateID);
            
            CreateTable(
                "dbo.QuickCreateModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OSLabel = c.String(),
                        ServiceName = c.String(),
                        Name = c.String(nullable: false),
                        SendLink = c.Boolean(nullable: false),
                        RecepientEmail = c.String(nullable: false),
                        VMPath = c.String(),
                        Machine_Size = c.String(nullable: false),
                        OS = c.String(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.QuickCreateSoftwaresPredefineds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuickCreateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuickCreateModels", t => t.QuickCreateID, cascadeDelete: true)
                .Index(t => t.QuickCreateID);
            
            CreateTable(
                "dbo.QuickCreateFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        QuickCreateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.QuickCreateModels", t => t.QuickCreateID, cascadeDelete: true)
                .Index(t => t.QuickCreateID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.WebAccesses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        EndPoint = c.String(),
                        AccessToken = c.String(),
                        UserMail = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.QuickCreateFiles", "QuickCreateID", "dbo.QuickCreateModels");
            DropForeignKey("dbo.QuickCreateSoftwaresPredefineds", "QuickCreateID", "dbo.QuickCreateModels");
            DropForeignKey("dbo.QuickCreateSoftwaresCustoms", "QuickCreateID", "dbo.QuickCreateModels");
            DropForeignKey("dbo.QuickCreateModels", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.LabVMs", "Lab_ID", "dbo.Labs");
            DropForeignKey("dbo.LabFiles", "LabID", "dbo.Labs");
            DropForeignKey("dbo.LabDataDisks", "LabID", "dbo.Labs");
            DropForeignKey("dbo.PredefinedSoftwares", "Name", "dbo.LabCreates");
            DropForeignKey("dbo.Participants", "LabCreate_Name", "dbo.LabCreates");
            DropForeignKey("dbo.LabSoftwarePredefineds", "SoftwareID", "dbo.Softwares");
            DropForeignKey("dbo.LabSoftwarePredefineds", "LabID", "dbo.Labs");
            DropForeignKey("dbo.LabParticipants", "LabID", "dbo.Labs");
            DropForeignKey("dbo.LabConfigurations", "LabID", "dbo.Labs");
            DropForeignKey("dbo.LabSoftwareCustoms", "LabID", "dbo.Labs");
            DropForeignKey("dbo.Billings", "LabID", "dbo.Labs");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Labs", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.QuickCreateFiles", new[] { "QuickCreateID" });
            DropIndex("dbo.QuickCreateSoftwaresPredefineds", new[] { "QuickCreateID" });
            DropIndex("dbo.QuickCreateModels", new[] { "ApplicationUserID" });
            DropIndex("dbo.QuickCreateSoftwaresCustoms", new[] { "QuickCreateID" });
            DropIndex("dbo.LabVMs", new[] { "Lab_ID" });
            DropIndex("dbo.LabFiles", new[] { "LabID" });
            DropIndex("dbo.LabDataDisks", new[] { "LabID" });
            DropIndex("dbo.PredefinedSoftwares", new[] { "Name" });
            DropIndex("dbo.Participants", new[] { "LabCreate_Name" });
            DropIndex("dbo.LabSoftwarePredefineds", new[] { "LabID" });
            DropIndex("dbo.LabSoftwarePredefineds", new[] { "SoftwareID" });
            DropIndex("dbo.LabParticipants", new[] { "LabID" });
            DropIndex("dbo.LabConfigurations", new[] { "LabID" });
            DropIndex("dbo.LabSoftwareCustoms", new[] { "LabID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Labs", new[] { "ApplicationUserID" });
            DropIndex("dbo.Billings", new[] { "LabID" });
            DropTable("dbo.WebAccesses");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.QuickCreateFiles");
            DropTable("dbo.QuickCreateSoftwaresPredefineds");
            DropTable("dbo.QuickCreateModels");
            DropTable("dbo.QuickCreateSoftwaresCustoms");
            DropTable("dbo.LabVMs");
            DropTable("dbo.LabFiles");
            DropTable("dbo.LabDataDisks");
            DropTable("dbo.PredefinedSoftwares");
            DropTable("dbo.Participants");
            DropTable("dbo.LabCreates");
            DropTable("dbo.Softwares");
            DropTable("dbo.LabSoftwarePredefineds");
            DropTable("dbo.LabParticipants");
            DropTable("dbo.LabConfigurations");
            DropTable("dbo.LabSoftwareCustoms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Labs");
            DropTable("dbo.Billings");
        }
    }
}
