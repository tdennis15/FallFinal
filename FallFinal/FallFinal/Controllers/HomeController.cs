using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FallFinal.Models;

namespace FallFinal.Controllers
{
    public class HomeController : Controller
    {
        //adding in our context class for the use in the controller
        private AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Items()
        {
            var item = db.Items;
            return View(item);
        }



        /// <summary>
        /// Here is the shell for the get method in the controller for the CRUD create page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }

        /// <summary>
        /// Here is the post for the CRUD method of create in our application
        /// We have a form passed in from the html page so that we can use elements to 
        /// identify pieces of the data to put into our database and so that the form 
        /// validation because simpler.
        /// 
        /// </summary>
        /// <param name="collection">just a simple form</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateItem(FormCollection collection)
        {
            try
            {
                Item item = db.Items.Create();

                item.I_Name = collection["itemName"];
                return RedirectToAction("Index");
            }

            catch
            {
                return View("Index");
            }
        }
    }
}