using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppWeb.Models;
using Microsoft.AspNet.Identity;

namespace AppWeb.Controllers
{
    public class AddStoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddStores
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var MyOrder = from Order in db.AddStores
                          where Order.UserId == UserId && Order.TrueuOrFalse == false
                          select Order;

            return View(MyOrder.ToList());
          
        }
           public ActionResult MyOrder()
        {
            var UserId = User.Identity.GetUserId();
            var MyOrder = from Order in db.AddStores
                          where Order.UserId == UserId && Order.TrueuOrFalse == true
                          select Order;

            return View(MyOrder.ToList());
        }

        public ActionResult Comments()
        {
            return View();
        }
      [HttpPost]
       public ActionResult Comments(string StoreId, Comment comment)
        {
       
            comment.UserId = User.Identity.GetUserId();
            comment.StoreId = StoreId;
            comment.FullName= User.Identity.FullName();
            comment.DateTime= DateTime.Now;
           
            string Id = DateTime.Now.ToString("yyyyMMddThhmmss");
            comment.Id = EncryptAndDecrypt.EncryptString(Id).Replace("/", "-").Replace(" ", "-").Replace("+", "-");
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: AddStores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddStore addStore = db.AddStores.Find(id);
            if (addStore == null)
            {
                return HttpNotFound();
            }
            return View(addStore);
        }

        // GET: AddStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(AddStore addStore)
        {
            if (ModelState.IsValid)
            {
               
               
                addStore.UserId= User.Identity.GetUserId();
                addStore.District = User.Identity.District();
                addStore.City = User.Identity.City();
                addStore.Street = User.Identity.Street();
                addStore.ProducetAddDateTime = DateTime.Now;

                string Id = DateTime.Now.ToString("yyyyMMddThhmmss");
                addStore.Id = EncryptAndDecrypt.EncryptString(Id).Replace("/", "-").Replace(" ", "-").Replace("+", "-");
                db.AddStores.Add(addStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addStore);
        }

        // GET: AddStores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddStore addStore = db.AddStores.Find(id);
            if (addStore == null)
            {
                return HttpNotFound();
            }
            return View(addStore);
        }
        [HttpPost]
        public ActionResult Edit(AddStore addStore)
        {
            if (ModelState.IsValid)
            {
                addStore.UserId = User.Identity.GetUserId();
                addStore.District = User.Identity.District();
                addStore.City = User.Identity.City();
                addStore.Street = User.Identity.Street();
                addStore.ProducetAddDateTime = DateTime.Now;
                addStore.TrueuOrFalse = true;

                db.Entry(addStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addStore);
        }

        // POST: AddStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: AddStores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddStore addStore = db.AddStores.Find(id);
            if (addStore == null)
            {
                return HttpNotFound();
            }
            return View(addStore);
        }

        // POST: AddStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AddStore addStore = db.AddStores.Find(id);
            db.AddStores.Remove(addStore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }












        /// <summary>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
