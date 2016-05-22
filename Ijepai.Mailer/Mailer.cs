using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.IO;
using ijpieMailer.Interface;


namespace ijpieMailer
{
    
    public class Mailer
    {
        #region Local Variables
        private string _smtp = "", _username = "", _password = "", _senderEmailAdress = "", _fromEmailAddress = "", _subject = "",
            _body = "", _fromDisplayName = "", _replyTo = "";
        private int _port;
        private bool _ssl;
        MailMessage _mMail;
        List<MailerAttachment> _attachments;
        private static IMailProviderFactory _factory = new SMTPMailProviderFactory();

        public static IMailProviderFactory Factory
        {
            set
            {
                _factory = value;
            }
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Use this constructor for Platform Level Emails needed by DevOps
        /// </summary>
        public Mailer()
        {
            LoadSettingsFromEnvironment();
            _mMail = new MailMessage();
            _attachments = new List<MailerAttachment>();
        }

        /// <summary>
        /// Use this constructor for OrgUnit Level emails sent on behalf of OrgUnit
        /// </summary>
        /// <param name="orgUnit"></param>
        public Mailer(string FromEmail, string FromEmailDisplayName)
        {
            LoadSettingsFromEnvironment();
            if (MailerRecipient.IsValidEmail(FromEmail))
            {
                _fromEmailAddress = FromEmail;
                _replyTo = FromEmail;
            }
            if (!string.IsNullOrEmpty(FromEmailDisplayName)) _fromDisplayName = FromEmailDisplayName;
            _mMail = new MailMessage();
            _attachments = new List<MailerAttachment>();

        }
        #endregion
        /// <summary>
        /// Use this constructor for AppUser level emails (e.g. Lightbox sharing etc.)
        /// </summary>
        /// <param name="orgUnit"></param>
        /// <param name="user"></param>
       

        public string FromEmailAddress
        {
            get
            {
                return _fromEmailAddress;
            }
            set
            {
                _fromEmailAddress = value;

            }
        }

        public string SenderEmailAddress
        {
            get
            {
                return _senderEmailAdress;
            }
            set
            {
                _senderEmailAdress = value;
            }
        }

        public string Body
        {

            get
            {
                return _body;
            }
            set
            {
                _body = value;

            }

        }

        public string Subject
        {

            get
            {
                return _subject;
            }
            set
            {
                _subject = value;

            }

        }
        /// <summary>
        /// Persistent: Karuna: Fix for 1178: Set the sender so that the name will appear in from address
        /// </summary>
        public string FromDisplayName
        {
            get { return _fromDisplayName; }
            set { _fromDisplayName = value; }
        }
        /// <summary>
        /// Persistent: Deepti. Defect 1466. ReplyTo property
        /// </summary>
        public string ReplyTo
        {
            get { return _replyTo; }
            set { _replyTo = value; }
        }

        public MailPriority Priority
        {
            get;
            set;
        }

        private void LoadSettingsFromEnvironment()
        {
            try
            {
                _senderEmailAdress = "Support@ijpie.com";
                _replyTo = _fromEmailAddress = "Support@ijpie.com";
                _fromDisplayName = "ijpie";
                _smtp = "mail.ijpie.com";
                _username = "Support@ijpie.com";
                _password = "Ijpie@123";
                _ssl = false;
                _port = 587;
            }
            catch (Exception ex)
            {
                
            }
        }


        #region Public Methods

        /// <summary>
        /// Creates a mailer object from template.  Quick compose to send to one recipient only. 
        /// </summary>
        /// <param name="orgUnitID"></param>
        /// <param name="mailTemplateCode"></param>
        /// <param name="messageTokenValues"></param>
        /// <param name="emailTo"></param>
        /// <param name="subjectTokenValues"></param>
        /// <param name="emailCC"></param>
        /// <param name="emailBcc"></param>
        public void Compose( string Link, string emailTo, string emailCC = null, string emailBcc = null, List<MailerAttachment> attachments = null)
        {
            MailerRecipient to = new MailerRecipient(emailTo);
            List<MailerRecipient> toList = new List<MailerRecipient>();
            toList.Add(to);
            List<MailerRecipient> ccList = null;
            if (!string.IsNullOrEmpty(emailCC))
            {
                MailerRecipient cc = new MailerRecipient(emailCC);
                if (ccList == null) ccList = new List<MailerRecipient>();
                ccList.Add(cc);
            }
            List<MailerRecipient> bccList = null;
            if (!string.IsNullOrEmpty(emailBcc))
            {
                MailerRecipient bcc = new MailerRecipient(emailBcc);
                if (bccList == null) bccList = new List<MailerRecipient>();
                bccList.Add(bcc);
            }
            Compose(Link, toList, ccList, bccList, attachments);
        }

        /// <summary>
        /// Creates a mailer object from template
        /// </summary>
        /// <param name="orgUnitID"></param>
        /// <param name="mailTemplateCode"></param>
        /// <param name="tokenValues"></param>
        /// <param name="toList"></param>
        /// <param name="ccList"></param>
        /// <param name="bccList"></param>
        public void Compose(string Link, List<MailerRecipient> toList, List<MailerRecipient> ccList = null, List<MailerRecipient> bccList = null, List<MailerAttachment> attachments = null)
        {
            //Get MailTemplate
            MailTemplate mailTemplate = new MailTemplate();
            
            string body = "Dear User";
            body += "<br/><br/>";
            body += "<a href='" + Link + "'>Click this link to access your Virtual Machine</a><br/>";
            body += "Regards,<br/>";
            body += "ijpie";
            body += "<br />";
            //body = "<html>\n    <body>\n        <div style=\"overflow: hidden;\"><font size=-1><div><table width=\"760\" style=\"width:750px;border-collapse:collapse\" border=\"0\" bgcolor=\"#000000\"><tr><td width=\"30\" style=\"width:30px\"> </td><td width=\"700\" style=\"width:700px\"><p style=\"font-size:10px;text-align:center;color:#fff;margin:0;font-family:Arial,Helvetica,sans-serif\">Add <a style=\"color:#fff\" href=\"mailTo:virtualmachine@ijpie.com\" target=\"_blank\">virtualmachine@ijpie.com</a> to your address book to ensure safe delivery.</p><table width=\"100%\" bgcolor=\"#FFFFFF\" border=\"0\" cellpadding=\"0px\" cellspacing=\"0px\"><tr bgcolor=\"#FFFFFF\"><td><img src=\"http://ijpie.azurewebsites.net/images/ijpielogo.png\"></td></tr><tr bgcolor=\"#FFFFFF\"><td align=\"center\"><img src=\"http://ijpie.azurewebsites.net/images/ijpiechip-612.png style=\"width:700px\"\"></td></tr><tr bgcolor=\"#FFFFFF\"><td><img src=\"http://events.mazdausa.com/events/mobile/email_assets/images/emailImg/car_03.png\"></td></tr></table><table width=\"100%\" bgcolor=\"#FFFFFF\" border=\"0\" cellpadding=\"0px\" cellspacing=\"0px\"><tr bgcolor=\"#FFFFFF\"><td width=\"700\" valign=\"top\" style=\"padding:0 20px\"><p style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px\">Dear rahul karn,</p><p style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px\">Thank you for choosing Ijpie.  As always with a Ijpie, there&#39;s a lot more to our solution than meets the eye.  Besides Ijpie&#39;s Easy and quick provisioning virtual Machines, the overall performance and features of Ijpie are the reason for its customers to be capable of doing amazing things on unlimited compute power..</p><p style=\"font-family:Arial,Helvetica,sans-serif;font-size:12px\">Just click on the link and access your virtual machine</p><table><tr><td><a href=\"http://events.mazdausa.com/events/mobile/Pdf_Res/45_Car_Colors.pdf\" style=\"border:none\" target=\"_blank\"><img style=\"border:none\" src=\"http://events.mazdausa.com/events/mobile/email_assets/images/emailImg/pdf_icon.gif\"><p style=\"font-family:Arial,Helvetica,sans-serif;font-size:10px;margin-top:0px\">Car Colors</p></a></td></tr></table><br><p style=\"padding-top:50px;font-size:11px;font-family:Arial,Helvetica,sans-serif\"><strong>Thank You</strong><br><br>Ijpie Creation team.<br></p><img style=\"margin:50px 0 10px 0\" src=\"http://events.mazdausa.com/events/mobile/email_assets/images/emailImg/zoom.png\" width=\"117\" height=\"16\"><br></td></tr><tr bgcolor=\"#000000\"><td width=\"700\" valign=\"top\" style=\"padding:0 20px\"><br><p style=\"font-size:9px;color:#c2c2c2;font-family:Arial,Helvetica,sans-serif\">Ijpie Technologies - 201 West Main street, El-Dorado, Arkansas 71730</p><p style=\"font-size:9px;color:#c2c2c2;font-family:Arial,Helvetica,sans-serif\">DO NOT REPLY to this email. If you have questions or comments, please contact us at <a style=\"color:#237cb7;font-family:Arial,Helvetica,sans-serif\" href=\"http://www.ijpie.com\" target=\"_blank\">www.ijpie.com</a></p><p style=\"font-size:9px;color:#c2c2c2;font-family:Arial,Helvetica,sans-serif\"></p></td></tr></table></td><td width=\"30\" style=\"width:30px\"> </td></tr></table></div>\n        </font></div>\n        </body>\n</html>";
            string subject = "Your ijpie Trial Virtual machine is ready";
            //all MailTemplate entity emails are HTML
            Compose(subject, body, toList, true, attachments, ccList, bccList);
           
        }

        public void Compose(string subject, string body, List<MailerRecipient> toList, bool isBodyHtml = true, List<MailerAttachment> attachments = null, List<MailerRecipient> ccList = null, List<MailerRecipient> bccList = null, MailerPriorityFlag priority = MailerPriorityFlag.Normal)
        {
            _mMail = new MailMessage();
            _mMail.Sender = new MailAddress(_senderEmailAdress);
            if (!string.IsNullOrEmpty(_fromEmailAddress))
            {
                if (!string.IsNullOrEmpty(_fromDisplayName))
                {
                    _mMail.From = new MailAddress(_fromEmailAddress, _fromDisplayName);
                }
                else
                {
                    _mMail.From = new MailAddress(_fromEmailAddress);
                }
            }
            if (!string.IsNullOrEmpty(_replyTo))
            {
                MailAddress replyToAddress;
                if (!string.IsNullOrEmpty(_fromDisplayName))
                {
                    replyToAddress = new MailAddress(_replyTo, _fromDisplayName);
                }
                else
                {
                    replyToAddress = new MailAddress(_replyTo);
                }
                _mMail.ReplyToList.Add(replyToAddress);
            }
            MailerRecipient.ConvertToMailAddressList(toList).ForEach(r => _mMail.To.Add(r));
            if (ccList != null) MailerRecipient.ConvertToMailAddressList(ccList).ForEach(r => _mMail.CC.Add(r));
            if (bccList != null) MailerRecipient.ConvertToMailAddressList(bccList).ForEach(r => _mMail.Bcc.Add(r));
            switch (priority)
            {
                case MailerPriorityFlag.High:
                    _mMail.Priority = MailPriority.High;
                    break;
                case MailerPriorityFlag.Low:
                    _mMail.Priority = MailPriority.Low;
                    break;
                default:
                    _mMail.Priority = MailPriority.Normal;
                    break;
            }
            _mMail.Subject = subject;
            _mMail.Body = body;
            _mMail.IsBodyHtml = isBodyHtml;

            if (attachments != null)
            {
                MailerAttachment.ConvertToAttachmentList(attachments).ForEach(a => _mMail.Attachments.Add(a));
            }

        }

        public bool SendMail(MailerPriorityFlag priority = MailerPriorityFlag.Normal)
        {
            var provider = _factory.Create(this._smtp, this._port, this._username, this._password, this._ssl);
            return provider.SendMail(_mMail, priority);
        }

        #endregion
    }

    public class MailerAttachment
    {
        string _fileName;
        Stream _content;
        string _mimeType;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public Stream Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public string MimeType
        {
            get { return _mimeType; }
            set { _mimeType = value; }
        }

        public MailerAttachment()
        {
        }

        public MailerAttachment(string filename, Stream content, string mimeType)
        {
            _fileName = filename;
            _content = content;
            _mimeType = mimeType;
        }

        public static Attachment ConvertToAttachment(MailerAttachment mailerAttachment)
        {
            Attachment attachment = null;
            if (mailerAttachment != null)
            {
                attachment = new Attachment(mailerAttachment.Content, mailerAttachment.FileName);
                try
                {
                    if (!string.IsNullOrEmpty(mailerAttachment.MimeType))
                        attachment.ContentType = new System.Net.Mime.ContentType(mailerAttachment.MimeType);
                }
                catch (Exception e)
                {
                   
                }
            }
            return attachment;
        }

        public static List<Attachment> ConvertToAttachmentList(List<MailerAttachment> mailerAttachmentList)
        {
            List<Attachment> attachmentList = null;
            if (mailerAttachmentList != null)
            {
                attachmentList = new List<Attachment>();
                mailerAttachmentList.ForEach(ma => attachmentList.Add(MailerAttachment.ConvertToAttachment(ma)));
            }
            return attachmentList;
        }

    }

    public class MailerRecipient
    {
        string _recipientName;
        string _emailAddress;

        public MailerRecipient()
        {
        }

        public MailerRecipient(string emailAddress, string recipientName = null)
        {
            _emailAddress = emailAddress;
            _recipientName = recipientName;
        }

        public string RecipientName
        {
            get
            {
                return _recipientName;
            }
            set
            {
                _recipientName = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
            }
        }

        public static MailAddress ConvertToMailAddress(MailerRecipient recipient)
        {
            MailAddress mailAddress;
            if (!string.IsNullOrEmpty(recipient.EmailAddress) && !string.IsNullOrEmpty(recipient.RecipientName))
            {
                mailAddress = new MailAddress(recipient.EmailAddress, recipient.RecipientName);
            }
            else if (!string.IsNullOrEmpty(recipient.EmailAddress))
            {
                mailAddress = new MailAddress(recipient.EmailAddress);
            }
            else
            {
                mailAddress = null;
            }
            return mailAddress;
        }

        public static List<MailAddress> ConvertToMailAddressList(List<MailerRecipient> recipientList)
        {
            List<MailAddress> addressList = null;
            if (recipientList != null)
            {
                addressList = new List<MailAddress>();
                foreach (MailerRecipient recipient in recipientList)
                {
                    MailAddress address = MailerRecipient.ConvertToMailAddress(recipient);
                    addressList.Add(address);
                }
            }
            return addressList;
        }

        /// <summary>
        /// Convert a comma separated email list to a MailerRecipient list 
        /// </summary>
        /// <param name="commaSeparatedEmailAddressList">use comma separated email address or email address with display name format (e.g. "email@domain.com, Display Name <email2@domain.com>") </param>
        /// <returns></returns>
        public static List<MailerRecipient> ConvertToRecipientList(string commaSeparatedEmailAddressList)
        {
            List<MailerRecipient> recipientList = null;
            if (!string.IsNullOrEmpty(commaSeparatedEmailAddressList))
            {
                recipientList = new List<MailerRecipient>();
                string[] recipientArr = commaSeparatedEmailAddressList.Split(new char[] { ',' });
                for (int i = 0; i < recipientArr.Length; i++)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(recipientArr[i]))
                        {
                            MailAddress mailAddress = new MailAddress(recipientArr[i]);
                            recipientList.Add(new MailerRecipient(mailAddress.Address, mailAddress.DisplayName));
                        }
                    }
                    catch (Exception e)
                    {
                       

                    }
                }
            }
            return recipientList;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public enum MailerPriorityFlag
    {
        High,
        Low,
        Normal
    }
}
      