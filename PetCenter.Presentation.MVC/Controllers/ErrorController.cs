using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCenter.Presentation.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index(HandleErrorInfo err)
        {
            return View("Error", err);
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;  //you may want to set this to 200
            return View("NotFound");
        }

        public ActionResult HttpError(string message)
        {
            return View("Error", message);
        }
    }
}