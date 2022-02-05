using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppWeb.Models;
using Microsoft.AspNet.Identity;
using GemBox.Document;

namespace AppWeb.Controllers
{
    [Authorize(Users = "Admin")]
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
    
        public static class Get
        {
            public static int id()
            {
                ApplicationDbContext db = new ApplicationDbContext();
                return db.Stores.Where(b => b.Id == b.Id).Count();



            }


        }

        // GET: Store
        public ActionResult Index()
        {
            return View(db.Stores.ToList());
        }
        public ActionResult MyOrderAddUser()
        {
            var Order = from orderId in db.AddStores
                        where orderId.StoreTrueuOrFalse == false
                        select orderId;

            return View(Order.ToList());
        }

        // GET: Store/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Store/Create   
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Store image, HttpPostedFileBase file1, HttpPostedFileBase file2,HttpPostedFileBase file3 ,HttpPostedFileBase file4,HttpPostedFileBase file5)
        {
          
                try
                {
                    //image 1
                    if (file1 != null)
                    {
                        string FileName = file1.FileName;
                        string newFile = FileName.Replace(file1.FileName, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss ") + "1.jpg");
                        string path = Path.Combine(Server.MapPath("~/Upload"), newFile);
                        file1.SaveAs(path);
                        image.image1 = newFile;

                    }
                    //image 2
                    if (file2 != null)
                    {
                        string FileName = file2.FileName;
                        string newFile = FileName.Replace(file2.FileName, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss ") + "2.jpg");
                        string path = Path.Combine(Server.MapPath("~/Upload"), newFile);
                        file2.SaveAs(path);
                        image.image2 = newFile;

                    }
                //image 3
                if (file3 != null)
                {
                    string FileName = file3.FileName;
                    string newFile = FileName.Replace(file3.FileName, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss ") + "3.jpg");
                    string path = Path.Combine(Server.MapPath("~/Upload"), newFile);
                    file3.SaveAs(path);
                    image.image3 = newFile;

                }
                //image 4
                if (file4 != null)
                {
                    string FileName = file4.FileName;
                    string newFile = FileName.Replace(file4.FileName, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss ") + "4.jpg");
                    string path = Path.Combine(Server.MapPath("~/Upload"), newFile);
                    file4.SaveAs(path);
                    image.image4 = newFile;

                }

                //image 5
                if (file5 != null)
                {
                    string FileName = file5.FileName;
                    string newFile = FileName.Replace(file5.FileName, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss ") + "5.jpg");
                    string path = Path.Combine(Server.MapPath("~/Upload"), newFile);
                    file5.SaveAs(path);
                    image.image5 = newFile;

                }



                image.UserId = User.Identity.GetUserId();
                    image.ProducetAddDateTime = DateTime.Now;
                string Id = DateTime.Now.ToString("yyyyMMddThhmmss");
                image.Id = EncryptAndDecrypt.EncryptString(Id).Replace("/", "-").Replace(" ", "-").Replace("+", "-");
                db.Stores.Add(image);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                catch (Exception er)
                {
                    ViewBag.er = er;   


                }
     
            return View();
        }


        // GET: Store/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Store/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ToPDF(string CityDistrictStreet,string FullName,string NumberMobie, string text)
        {
            string texts = FullName+ NumberMobie + text + CityDistrictStreet;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            DocumentModel document = new DocumentModel();

            Section section = new Section(document);
            document.Sections.Add(section);

            Paragraph paragraph = new Paragraph(document);
            section.Blocks.Add(paragraph);

            Run run = new Run(document, texts.Replace("+"," "));
              
            paragraph.Inlines.Add(run);
            string ID = text+".docx";
            var Url = Path.Combine(Server.MapPath("~/Upload/SaveToPDF"), ID);
            document.Save(Path.Combine(Server.MapPath("~/Upload/SaveToPDF"), ID));
            return RedirectToAction("");

        }

        [HttpPost]
        public  ActionResult OkOrder(string id,string TextToHome)
        {

            AddStore store = db.AddStores.Find(id);
            if (store == null)
            {

                return HttpNotFound();
            }
            var x = from i in db.Users
                    where i.Id == store.UserId
                    select new { FullName = i.FullName, PhoneNumber=i.PhoneNumber, Location = i.City+i.District+i.Street };
            foreach (var item in x)
            {
               string texts =item.FullName +item.PhoneNumber + item.Location + TextToHome;
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");

                DocumentModel document = new DocumentModel();

                Section section = new Section(document);
                document.Sections.Add(section);

                Paragraph paragraph = new Paragraph(document);
                section.Blocks.Add(paragraph);

                Run run = new Run(document, texts.Replace("+", " "));

                paragraph.Inlines.Add(run);
                string ID = TextToHome + ".pdf";
                var Url = Path.Combine(Server.MapPath("~/Upload/SaveToPDF"), ID);
                document.Save(Path.Combine(Server.MapPath("~/Upload/SaveToPDF"), ID));

            }
       
            store.TextToHome = TextToHome;
            store.ProducetAddDateTime = DateTime.Now;
            store.StoreTrueuOrFalse = true;
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();

            return RedirectToAction("MyOrderAddUser");
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string NP )
        {
            var id= EncryptAndDecrypt.EncryptString(NP.Replace("PN", "14").Replace("SA", "T")).Replace("/", "-").Replace(" ", "-").Replace("+", "-");
            /*
            var result = db.Stores.Where(a => a.Id.Contains(searchName)
            || a.ProducetName.Contains(searchName)).ToList();
            */
            var ID = from d in db.Stores
                     where d.Id == id 
                     select d;

          

            return View(ID);
        }
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
