using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using ValidationCodeHelper;

namespace WebApplication1.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Code()
        {
            DrawValidationCode code = new DrawValidationCode();
            code.FontMinSize = 26;
            code.FontMaxSize = 30;

            MemoryStream ms = new MemoryStream();
            code.CreateImage(ms);
            Session["code"] = code.ValidationCode;

            Response.ContentType = "image/gif";
            Response.BinaryWrite(ms.GetBuffer());

            return new EmptyResult();
        }
    }
}