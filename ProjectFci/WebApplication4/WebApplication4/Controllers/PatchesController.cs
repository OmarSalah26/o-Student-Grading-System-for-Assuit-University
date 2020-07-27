using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Dto;
using WebApplication4.Models;
using WebApplication4.Logic;

namespace WebApplication4.Controllers
{
    public class PatchesController : Controller
    {
        private readonly PatchLogic _Ipatch;

        public PatchesController()
        {
            _Ipatch = new PatchLogic();
        }
        // GET: Patches
        public ActionResult GetAll()
        {
            try
            {
                return View(_Ipatch.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: Patches/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                return View(_Ipatch.GetById(id));

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // GET: Patches/Create
        public ActionResult Create()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST: Patches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PatchName,PatchNumber")] PatchDto patch)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Ipatch.Insert(patch);
                    return RedirectToAction("GetAll");
                }

                return View(patch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Patches/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {
                PatchDto patch = _Ipatch.GetById(id);
                if (patch == null)
                {
                    return HttpNotFound();
                }
                return View(patch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        // POST: Patches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PatchName,PatchNumber")] PatchDto patch)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Ipatch.Update(patch, patch.ID);

                    return RedirectToAction("Index");
                }
                return View(patch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Patches/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {

                PatchDto patch = _Ipatch.GetById(id);
                if (patch == null)
                {
                    return HttpNotFound();
                }
                return View(patch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Patches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {

                _Ipatch.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
