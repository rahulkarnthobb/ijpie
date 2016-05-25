using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using SMLibrary;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApi.Models;
using Microsoft.AspNet.Identity;
using ijpieMailer;
using System.Xml;
using System.Text;
using System.Xml.Linq;

namespace WebApi.Controllers
{
    public class VmProvisionController : ApiController
    {
        

        // GET: api/VmProvision
        public IEnumerable<SelectListItem> Get()
        {
            return Getimages();
        }

        // GET: api/VmProvision
        public IEnumerable<SelectListItem> Get(String callback)
        {
            return Getimages();
        }

        public static Dictionary<string, string> imageList { get; set; }
        private IEnumerable<SelectListItem> Getimages()
        {
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            var swr = new StringWriter();
            imageList = vmm.GetAzureVMImages().Result;
            List<string> imageListRest = new List<string>();
            var imgLst = new List<SelectListItem>();
            foreach (KeyValuePair<string, string> entry in imageList)
            {
                imgLst.Add(new SelectListItem { Value = entry.Key, Text = entry.Value });
            }

            return imgLst;
        }
       
        // POST: api/VmProvision
        public void Post([FromBody]string value)
        {
            
           
        }

        // PUT: api/VmProvision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VmProvision/6
        public void Delete(int id)
        {
        }
    }

    public class VmDetailController : ApiController
    {


        // GET: api/VmProvision
        public JsonResult Get()
        {
            return GetDetail();
        }
        // GET: api/VmProvision
       

        public static Dictionary<string, string> imageList { get; set; }
        private JsonResult GetDetail()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var QCVM = new JsonResult();
            var name = Request.GetQueryNameValuePairs();
            string User = name.ElementAt(1).Key;
            QCVM.Data = db.QuickCreates.Where(l =>l.ApplicationUserID == User).ToList();
            QCVM.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return QCVM;
        }

        // POST: api/VmProvision
        public void Post([FromBody]string value)
        {


        }

        // PUT: api/VmProvision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VmProvision/6
        public void Delete(int id)
        {
        }
    }

    public class VmDeleteController : ApiController
    {


        // GET: api/VmProvision
        public bool Get()
        {
            return Delete();
        }
        // GET: api/VmProvision


        public static Dictionary<string, string> imageList { get; set; }
        private bool Delete()
        {
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            ApplicationDbContext db = new ApplicationDbContext();
            var name = Request.GetQueryNameValuePairs();
            int id = Int32.Parse(name.ElementAt(0).Key);
            var cloudService = db.QuickCreates.Where(l => l.ID == id).FirstOrDefault();
            try
            {
                string res = vmm.DeleteQCV(cloudService.ServiceName);
            }
            catch (Exception e)
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
            return true;

        }

        // POST: api/VmProvision
        public void Post([FromBody]string value)
        {


        }

        // PUT: api/VmProvision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VmProvision/6
        public void Delete(int id)
        {
        }
    }

    public class VmAccessController : ApiController
    {
        // GET: api/VmAccess
        //public IEnumerable<SelectListItem> Get()
        public string Get()
        {
            var name = Request.GetQueryNameValuePairs();
            string accessToken = name.ElementAt(1).Value;
            ApplicationDbContext db = new ApplicationDbContext();
            var machine = db.WebAccessess.Where(l => l.AccessToken == accessToken).FirstOrDefault();
            return machine.EndPoint;
        }

    }
   
    public class VmCreateController : ApiController
    {


        string pwd = "1234Test!";
        string vmname = "";
        // GET: api/VmCreate
        public bool Get()
        {
            string serviceName = Guid.NewGuid().ToString();
            var name = Request.GetQueryNameValuePairs();
            string Size = name.ElementAt(1).Value;
            string OS = name.ElementAt(2).Value;
            string usrname = name.ElementAt(3).Value;
            string email = name.ElementAt(4).Value;
            string osname = name.ElementAt(5).Value;

            //QueryString["OS"];
            //var pwd = Request.QueryString["Size"];
            QuickCreate model = new QuickCreate();
            ApplicationDbContext db = new ApplicationDbContext();
            int index = Size.IndexOf(' ');
            model.Machine_Size = Size.Substring(0, index);
            model.ApplicationUserID = usrname;
            model.OSLabel = OS;
            model.RecepientEmail = email;
            vmname = "IjpieVm";
            model.Name = vmname;
            model.OS = osname;
            model.ServiceName = serviceName;
            var status = GenerateVMConfig(model);
            
            db.QuickCreates.Add(model);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string Message = e.Message;
                return false;
            }



            WebAccess webAccess = new WebAccess();
            webAccess.EndPoint = serviceName + ".cloudapp.net";
            webAccess.UserName = "administrator";
            webAccess.Password = pwd;
            webAccess.UserMail = model.RecepientEmail;
            webAccess.ApplicationUserID = usrname;
            webAccess.AccessToken = Guid.NewGuid().ToString();
            db.WebAccessess.Add(webAccess);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                string Message = e.Message;
                return false;
            }

            //string link = "http://ijpieen.cloudapp.net/webaccess?accessToken=" + webAccess.AccessToken;
            string link = "http://ijpie.azurewebsites.net:54642/webaccess?accessToken=" + webAccess.AccessToken;
            Mailer mail = new Mailer("Support@ijpie.com", "ijpie");
            mail.Compose(link, model.RecepientEmail);
            mail.SendMail();
            return true;
        }


        // POST: api/VmProvision
        public void Post([FromBody]string value)
        {

           
        }

        async public Task<bool> GenerateVMConfig(QuickCreate model)
        {
            VMManager vmm = GetVMM();

            if (await vmm.IsServiceNameAvailable(model.Name).ConfigureAwait(continueOnCapturedContext: false) == false)
            {
                return false;
            }

            bool isVmImage = false;
            string ImageName = "";
            string ImagePath = "";
            XDocument vm = vmm.NewAzureVMConfig(model.Name, model.Machine_Size, model.OS, GetOSDiskMediaLocation(model.OSLabel), true, isVmImage, ImageName, ImagePath);
            if (!isVmImage)
            {

                vm = vmm.NewWindowsProvisioningConfig(vm, model.Name, pwd);
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

            String requestID_cloudService = await vmm.NewAzureCloudService(model.ServiceName, "West US", String.Empty).ConfigureAwait(continueOnCapturedContext: false);

            OperationResult result = await vmm.PollGetOperationStatus(requestID_cloudService, 5, 120).ConfigureAwait(continueOnCapturedContext: false);
            String requestID_createDeployment;
            if (result.Status == OperationStatus.Succeeded)
            {
                // VM creation takes too long so we'll check it later
                requestID_createDeployment = await vmm.NewAzureVMDeployment(model.ServiceName, model.Name, String.Empty, vm, null, isVmImage).ConfigureAwait(continueOnCapturedContext: false);
                OperationResult resultvm = await vmm.PollGetOperationStatus(requestID_createDeployment, 5, 120).ConfigureAwait(continueOnCapturedContext: false);
            }
            else
            {
                requestID_createDeployment = "";
            }

            return true;


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

                }
            }

            return imageLocation;
        }


        private String GetOSDiskMediaLocation(string imageName)
        {

            String osdiskmedialocation = GetVMImageDiskLocation(imageName).Result;
            if (osdiskmedialocation == string.Empty)
            {
                osdiskmedialocation = String.Format("https://{0}.blob.core.windows.net/vhds/{1}-OS-{2}.vhd", ConfigurationManager.AppSettings["StorageAccount"], vmname, Guid.NewGuid().ToString());
            }
            return osdiskmedialocation;
        }

        private VMManager GetVMM()
        {
            return new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
        }


        // PUT: api/VmProvision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VmProvision/6
        public void Delete(int id)
        {
        }
    }

    public class VmsizeController : ApiController
    {
        // GET: api/VmsizeController
        public IEnumerable<SelectListItem> Get()
        {
            return Getsize();
        }
        public static Dictionary<string, string> imageList { get; set; }
        private IEnumerable<SelectListItem> Getsize()
        {
            VMManager vmm = new VMManager(ConfigurationManager.AppSettings["SubcriptionID"], ConfigurationManager.AppSettings["CertificateThumbprint"]);
            var swr = new StringWriter();
            imageList = vmm.GetAzureVMSizes().Result;
            List<string> imageListRest = new List<string>();
            var imgLst = new List<SelectListItem>();
            foreach (KeyValuePair<string, string> entry in imageList)
            {
                imgLst.Add(new SelectListItem { Value = entry.Key, Text = entry.Value });
            }

            return imgLst;
        }

        // GET: api/VmProvision/7
        public string Get(string exec)
        {
            switch (exec)
            {
                case "getImgList":
                    //Getimages();
                    break;
                default:
                    break;
            }
            return "value";
        }

        // POST: api/VmProvision
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VmProvision/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VmProvision/6
        public void Delete(int id)
        {
        }
    }
}
/*
public class JsonpResult : JsonResult
{
    object data = null;

    public JsonpResult()
    {
    }

    public JsonpResult(object data)
    {
        this.data = data;
    }

    public override void ExecuteResult(ControllerContext controllerContext)
    {
        if (controllerContext != null)
        {
            HttpResponseBase Response = controllerContext.HttpContext.Response;
            HttpRequestBase Request = controllerContext.HttpContext.Request;

            string callbackfunction = Request["callback"];
            if (string.IsNullOrEmpty(callbackfunction))
            {
                throw new Exception("Callback function name must be provided in the request!");
            }
            Response.ContentType = "application/x-javascript";
            if (data != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.Write(string.Format("{0}({1});", callbackfunction, serializer.Serialize(data)));
            }
        }
    }
}
*/