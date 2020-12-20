using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using ValidationCode1;

namespace WebApplication1.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Code()
        {
            var v = new ValidatedCode();
            string code = v.CreateVerifyCode();

            Session["code"] = code;

            Response.ClearContent();
            Response.ContentType = "image/jpeg";
            using (MemoryStream ms = new MemoryStream())
            {
                v.CreateImageOnPage(code, ms);
                Response.BinaryWrite(ms.GetBuffer());
            }

            return new EmptyResult();
        }
    }
}