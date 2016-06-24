using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudyBot.Models;

namespace CrudyBot.Controllers
{
    public partial class BotCommsController : Controller
    {
        private BotCommsContext db = new BotCommsContext();

        // GET: BotComms
        public virtual ActionResult Index()
        {
            return View(db.BotComms.ToList());
        }

        // GET: BotComms/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BotComm botComm = db.BotComms.Find(id);
            if (botComm == null)
            {
                return HttpNotFound();
            }
            return View(botComm);
        }

        // GET: BotComms/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: BotComms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create([Bind(Include = "Id,MessageText,ResponseText,MIMEType")] BotComm botComm)
        {
            if (ModelState.IsValid)
            {
                db.BotComms.Add(botComm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(botComm);
        }

        // GET: BotComms/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BotComm botComm = db.BotComms.Find(id);
            if (botComm == null)
            {
                return HttpNotFound();
            }
            return View(botComm);
        }

        // POST: BotComms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "Id,MessageText,ResponseText,MIMEType")] BotComm botComm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(botComm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(botComm);
        }

        // GET: BotComms/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BotComm botComm = db.BotComms.Find(id);
            if (botComm == null)
            {
                return HttpNotFound();
            }
            return View(botComm);
        }

        // POST: BotComms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            BotComm botComm = db.BotComms.Find(id);
            db.BotComms.Remove(botComm);
            db.SaveChanges();
            return RedirectToAction("Index");
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
