//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using WebApplication4.Models;

//namespace WebApplication4.Controllers
//{
//    public class RolesController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: Roles
//        public ActionResult Index()
//        {
//            var rolesForUser = db.RolesForUser.Include(r => r.user);
//            return View(rolesForUser.ToList());
//        }

//        // GET: Roles/Details/5
//        public ActionResult Details(long? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Role roles = db.RolesForUser.Find(id);
//            if (roles == null)
//            {
//                return HttpNotFound();
//            }
//            return View(roles);
//        }

//        // GET: Roles/Create
//        public ActionResult Create()
//        {
//            ViewBag.userid = new SelectList(db.Users, "ID", "UserName");
//            return View();
//        }

//        // POST: Roles/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create( Role roles)
//        {
//            if (ModelState.IsValid)
//            {
//                db.RolesForUser.Add(roles);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.userid = new SelectList(db.Users, "ID", "UserName", roles.userid);
//            return View(roles);
//        }

//        // GET: Roles/Edit/5
//        public ActionResult Edit(long? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Role roles = db.RolesForUser.Find(id);
//            if (roles == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.userid = new SelectList(db.Users, "ID", "UserName", roles.userid);
//            return View(roles);
//        }

//        // POST: Roles/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "ID,RoleName,userid")] Role roles)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(roles).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.userid = new SelectList(db.Users, "ID", "UserName", roles.userid);
//            return View(roles);
//        }

//        // GET: Roles/Delete/5
//        public ActionResult Delete(long? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Role roles = db.RolesForUser.Find(id);
//            if (roles == null)
//            {
//                return HttpNotFound();
//            }
//            return View(roles);
//        }

//        // POST: Roles/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(long id)
//        {
//            Role roles = db.RolesForUser.Find(id);
//            db.RolesForUser.Remove(roles);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
