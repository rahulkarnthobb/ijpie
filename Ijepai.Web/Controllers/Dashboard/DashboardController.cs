﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ijpie.Web.Models;
using SMLibrary;
using System.Configuration;
using System.Xml.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ijpieMailer;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Windows.Forms;
using ijpie.Encrypt;


namespace ijpie.Web.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        static string guid = Guid.NewGuid().ToString();
        string serviceName = "ijpie" + guid;
        string vmName = string.Empty;
        string password = "1234Test!";
        bool isVmImage = false;
        string ImageName = "";
        string ImagePath = "";
        
        [HttpPost]
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return PartialView("_DashboardPartial");
        }

        public static Dictionary<string, string> imageList {get; set;}
        public async Task<JsonResult> Getimages()
        {
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            var swr = new StringWriter();
            imageList = await vmm.GetAzureVMImages();
            List<string> imageListRest = new List<string>();
            var imgLst = new List<SelectListItem>();
            foreach (KeyValuePair<string, string> entry in imageList)
            {
                imgLst.Add(new SelectListItem{ Value =entry.Key, Text =entry.Value});
            }

            TempData["OS"] = imgLst;

            return Json(new { Status = 0, MessageTitle = "Success" });
        }

        public JsonResult GetVmSizes()
        {
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            var swr = new StringWriter();
            imageList =  vmm.GetAzureVMSizes().Result;
            List<string> imageListRest = new List<string>();
            var imgLst = new List<SelectListItem>();
            foreach (KeyValuePair<string, string> entry in imageList)
            {
                imgLst.Add(new SelectListItem { Value = entry.Key, Text = entry.Value });
            }

            TempData["Size"] = imgLst;

            return Json(new { Status = 0, MessageTitle = "Success" });
        }

        string label { get; set; }
        public async Task<string> GetVMLabel(string imgName)
        {
            string Label;
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            imageList = await vmm.GetAzureVMImages();
            imageList.TryGetValue(imgName, out Label);
            label = Label;
            return label;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public JsonResult GetQC()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var QCVM = db.QuickCreates.Select(l => new { l.ID, l.Name, l.Machine_Size, l.OSLabel, l.RecepientEmail, l.ServiceName }).ToList();
            return Json(new { Status = 0, TotalItems = QCVM.Count(), rows = QCVM, org = Session["org"] });
        }

        // POST: /Dashboard/Create
        [HttpPost]
        async public Task<JsonResult> QuickCreate(QuickCreateModel model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            model.ApplicationUserID = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == model.ApplicationUserID).FirstOrDefault();
            model.RecepientEmail = model.RecepientEmail ?? user.Email_Address;
            vmName = model.Name;
            await GetVMLabel(model.OS);
            model.OSLabel = label;
            model.ServiceName = serviceName;
            var status = GenerateVMConfig(model);       
            db.QuickCreates.Add(model);
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
                string Message = e.Message;
            }
            
            string passPhrase = "th0bb@123";
            string encService = StringCipher.Encrypt(serviceName + ".cloudapp.net", passPhrase);
            string encUserName = StringCipher.Encrypt("administrator", passPhrase);
            string encPassword = StringCipher.Encrypt(password, passPhrase);

            
            WebAccess webAccess = new WebAccess();
            webAccess.EndPoint = serviceName + ".cloudapp.net";
            webAccess.UserName = "administrator";
            webAccess.Password = password;
            webAccess.UserMail = model.RecepientEmail;
            webAccess.AccessToken = Guid.NewGuid().ToString();
            db.WebAccesses.Add(webAccess);
            db.SaveChanges();
 
            //string link = "http://vmengine.azurewebsites.net/?" +StringCipher.initVector +"/" + "QC"+ "/"+ encService + "/" + encUserName + "/" + encPassword;
            string link = "http://ijepaiwebap.azurewebsites.net/webaccess?accessToken=" + webAccess.AccessToken;
            Mailer mail = new Mailer("Support@ijpie.com", "ijpie");
            mail.Compose(link, model.RecepientEmail);
            mail.SendMail();
            return Json(new { Status = 0, VMName = vmName, ServiceName = serviceName });
        }


         public JsonResult DeleteQCVM(int id)
        {           
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            ApplicationDbContext db = new ApplicationDbContext();
            var cloudService = db.QuickCreates.Where(l => l.ID == id ).FirstOrDefault();
            try
            {
              string res=  vmm.DeleteQCVM(cloudService.ServiceName).Result;
            }
            catch(Exception e)
            {
               // string message = e.InnerException.ToString();
                db.QuickCreates.Remove(cloudService);
                db.SaveChanges();

            }
            if (cloudService != null)
            {
                db.QuickCreates.Remove(cloudService);
                db.SaveChanges();
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
           // return Json(new { Status = 0 });
        }

        async public Task<JsonResult> CaptureQCVM(int id, string ImageName)
        {
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            ApplicationDbContext db = new ApplicationDbContext();
            var cloudService = db.QuickCreates.Where(l => l.ID == id).FirstOrDefault();
            await vmm.ShutDownVM(cloudService.ServiceName, cloudService.Name);
            VirtualMachineCaptureVMImageParameters param = new VirtualMachineCaptureVMImageParameters();
            param.VMImageLabel = "NewVmImage";
            param.VMImageName = "NewVmImage";
            param.OSState = "Specialized";
            System.Threading.CancellationToken token = new System.Threading.CancellationToken(false);
            await vmm.CaptureVM(cloudService.ServiceName, cloudService.Name, param.VMImageName);
            await vmm.RebootVM(cloudService.ServiceName, cloudService.Name);
            return Json(new { Status = 0 });
        }

        public async Task<JsonResult> GetVMStatus(string ServiceName, string VMName, string id)
        {
            VMManager vmm = GetVMM();
            string instanceStatus = string.Empty;
            string powerState = string.Empty;
            XDocument vmXML = await vmm.GetAzureVM(ServiceName, VMName);
            var statusm = vmXML.Root.Descendants(vmm.ns + "RoleInstanceList");
            foreach(var status in statusm)
            {
                instanceStatus = status.Element(vmm.ns + "RoleInstance").Element(vmm.ns + "InstanceStatus").Value;
                powerState = status.Element(vmm.ns + "RoleInstance").Element(vmm.ns + "PowerState").Value;
            }
            return Json(new {
                Status=0,
                InstanceStatus = instanceStatus,
                PowerState = powerState,
                VMName = VMName,
                ServiceName = ServiceName,
                id = id
            });
        }


        public ActionResult GetView()
        {
            Task<JsonResult> result = Getimages();
            JsonResult resultnew = GetVmSizes();
            return PartialView("_DashboardPartial");
        }

        async public Task<JsonResult> GenerateVMConfig(QuickCreateModel model)
        {
            VMManager vmm = GetVMM();

            if (await vmm.IsServiceNameAvailable(serviceName).ConfigureAwait(continueOnCapturedContext:false) == false)
            {
                return Json(new { Status=OperationStatus.Failed});
            }
            

            XDocument vm = vmm.NewAzureVMConfig(vmName,model.Machine_Size , model.OS, GetOSDiskMediaLocation(model.OSLabel), true, isVmImage, ImageName, ImagePath);
            if (!isVmImage)
            {

                vm = vmm.NewWindowsProvisioningConfig(vm, vmName, password);
                vm = vmm.NewNetworkConfigurationSet(vm);
                vm = vmm.AddNewInputEndpoint(vm, "web", "TCP", 80, 80);
                vm = vmm.AddNewInputEndpoint(vm, "rdp", "TCP", 3389, 3389);
            }
           

            var builder = new StringBuilder();
            var settings = new XmlWriterSettings()
            {
                Indent = true
            };
            using (var writer = XmlWriter.Create(builder, settings))
            {
                vm.WriteTo(writer);
            }

            String requestID_cloudService = await vmm.NewAzureCloudService(serviceName, "West US", String.Empty).ConfigureAwait(continueOnCapturedContext: false);

            OperationResult result = await vmm.PollGetOperationStatus(requestID_cloudService, 5, 120).ConfigureAwait(continueOnCapturedContext: false);
            String requestID_createDeployment;
                if (result.Status == OperationStatus.Succeeded)
                {
                    // VM creation takes too long so we'll check it later
                    requestID_createDeployment = await vmm.NewAzureVMDeployment(serviceName, vmName, String.Empty, vm, null, isVmImage).ConfigureAwait(continueOnCapturedContext:false);
                    OperationResult resultvm = await vmm.PollGetOperationStatus(requestID_createDeployment, 5, 120).ConfigureAwait(continueOnCapturedContext: false);
            }
                else
                {
                    requestID_createDeployment = "";
                }

                return Json(new { Status = result.Status, ServiceName = serviceName , VMName = vmName});
        }

        async private Task<String> GetVMImageDiskLocation(string imageName)
        {
            XNamespace ns = "http://schemas.microsoft.com/windowsazure";
            VMManager vmm = GetVMM();
            string imageLocation = string.Empty;
            XDocument xml = await vmm.GetUserVMImages();
            var images = xml.Root.Descendants(ns + "VMImage").Where(i => i.Element(ns + "Category").Value == "User");
            foreach (var image in images)
            {
                string imgName = image.Element(ns + "Name").Value;   
                if (imageName == imgName)
                {
                    imageLocation = image.Element(ns + "OSDiskConfiguration").Element(ns + "MediaLink").Value;
                    isVmImage = true;
                    ImageName = imgName;
                    ImagePath = imageLocation;
                }
            }
             
            return imageLocation;
        }


        private String GetOSDiskMediaLocation(string imageName)
        {
            
            String osdiskmedialocation = GetVMImageDiskLocation(imageName).Result;
            if (osdiskmedialocation == string.Empty)
            {
               osdiskmedialocation = String.Format("https://{0}.blob.core.windows.net/vhds/{1}-OS-{2}.vhd", ConfigurationManager.AppSettings["StorageAccount"], vmName, Guid.NewGuid().ToString());
            }
            return osdiskmedialocation;
        }

        private VMManager GetVMM()
        {
            return new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
        }
	}
}