using Google_reCAPTACHA_in_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using reCAPTCHA.MVC;

namespace Google_reCAPTACHA_in_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        [WebMethod]
        [CaptchaValidator(
        PrivateKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
        ErrorMessage = "Invalid input captcha.",
        RequiredMessage = "The captcha field is required.")]
        public JsonResult Submit(FormCollection formcollection)
        {
            try
            {
                RegistrationForm form = new RegistrationForm();
                form.FullName = formcollection["FullName"];

                CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);

                if (response.Success)
                {
                    return Json(1);
                }
                return Json(0);
            }
            catch (Exception ex)
            {
                return Json(ex.Message + ex.InnerException.Message);
            }
        }

        /// <summary>  
        /// Validate Captcha  
        /// </summary>  
        /// <param name="response"></param>  
        /// <returns></returns>  
        public static CaptchaResponse ValidateCaptcha(string response)
        {
            string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["recaptchaPrivateKey"];
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());
        } 

    }
}