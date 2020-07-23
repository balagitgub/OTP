using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OTP.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
namespace OTP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(model person)
        {
            Random r = new Random();
            string OTP = r.Next(1000, 9999).ToString();
            string PH = person.Phonenumber;
            const string accountSid = "ACcddb1ab2fd24e62badd680a6f1aec966";
            const string authToken = "d80221e9202d321bcd3fbcbe8ceab64c";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Your OTP is: " +OTP,
                from: new Twilio.Types.PhoneNumber("+12029337942"),
                to: new Twilio.Types.PhoneNumber("+91"+ PH + "")
            );

            

            
            Session["OTP"] = OTP;

            //Redirect for varification
           
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}