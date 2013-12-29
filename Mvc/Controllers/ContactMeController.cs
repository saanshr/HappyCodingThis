using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using HappyCodingThis.SitefinityWebApp.Mvc.Models;

namespace HappyCodingThis.SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "ContactMe", Title = "ContactMe", SectionName = "MvcWidgets")]
    public class ContactMeController : Controller
    {

        public ActionResult Index()
        {
            

            return View("Default");
        }
	   
	   [HttpPost]
	   public ActionResult Index(ContactMeModel model)
	   {
		  return View("ThankYou");
	   }
    }
}