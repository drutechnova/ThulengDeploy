using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Thuleng.Models;

namespace Thuleng.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Contacts()
        //{
        //    FeedbackForm temp = new FeedbackForm();
        //    temp.Message = @Resources.Global.Contacts_Form_Message_Field;
        //    return View(temp);
        //}


        [HttpPost]
        public ActionResult Contacts(ContactModel model)
        {
            string Text = "<html> <head> </head>" +
            " <body style= \" font-size:12px; font-family: Arial\">" +
            model.Message +
            "</body></html>";

            SendEmail("andrewrikhamba@gmail.com", Text);
            //FeedbackForm tempForm = new FeedbackForm();
            return Index();
        }


        public static bool SendEmail(string SentTo, string Text)
        {
            var msg = new MailMessage
                {
                    From = new MailAddress("info@test.com", "Andrew")
                };

            msg.To.Add(SentTo);
            msg.Subject = "Password";
            msg.Body = Text;
            msg.Priority = MailPriority.High;
            msg.IsBodyHtml = true;

            var client = new SmtpClient("mail.technova.co.za",587);

            client.Credentials = new NetworkCredential();


            //client.EnableSsl = true;

            try
            {
                client.Send(msg);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
