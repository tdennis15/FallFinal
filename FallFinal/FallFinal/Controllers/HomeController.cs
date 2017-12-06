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
            var itema = db.Items;
            return View(itema);
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
                item.Seller.Seller_Name = collection["sellerName"];
                item.I_Description = collection["itemDescription"];

                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Items");
            }

            catch
            {
                return View("Items");
            }
        }


        // GET: Details about an item 
        public ActionResult Details(int id)
        {
            var artist = db.Items.Where(a => a.I_ID == id).FirstOrDefault();
            return View(artist);
        }


        // GET: Edit Item Details
        public ActionResult Edit(int id)
        {
            ViewBag.aName = db.Items.Where(a => a.I_ID == id).FirstOrDefault().I_Name;
            ViewBag.aDescription = db.Items.Where(a => a.I_ID == id).FirstOrDefault().I_Description;
            
            return View();
        }

        // POST: Update the database with the posted details
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var ItemToUpdate = db.Items.Find(id);

               ItemToUpdate.I_Name = collection["Name"];
               ItemToUpdate.I_Description = collection["Description"];


                db.SaveChanges();

                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Form to delete an artist
        public ActionResult Delete(int id)
        {
            var artist = db.Items.Where(a => a.I_ID == id).FirstOrDefault();

            //viewbags so that we can populate the fields in our edit field so that data that wont be changed
            // doesnt have to be retyped
            ViewBag.aName = db.Items.Where(a => a.I_ID == id).FirstOrDefault().I_Name;
            ViewBag.aDescription = db.Items.Where(a => a.I_ID == id).FirstOrDefault().I_Description;
           

            return View("Items");
        }

        // POST: Deleting the artist from DB
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var item = db.Items.Find(id);

                db.Items.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Artists");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult BidResult(int? id)
        {
            //data checking for sanity
            if (id == null)
            {
                return null;
            }

            //our JSON object that will be returned
            var bid = db.Bids.Where(g => g.Item_ID == id) //getting the Item from the ID
                              .ToList(); //return it as a list type instead of an enumerable.
            return Json(bid, JsonRequestBehavior.AllowGet); //return the object to the CustomJS.js JavaAJAX_Call function.
        }

    
}
}