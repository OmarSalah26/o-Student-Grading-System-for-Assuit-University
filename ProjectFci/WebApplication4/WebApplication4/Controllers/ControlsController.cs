using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Dto;
using WebApplication4.Logic;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ControlsController : Controller
    {

        private ControlLogic _Control;
        public ControlsController()
        {
            _Control = new ControlLogic();
        }
        // GET: Controls
        public ActionResult GetAll()
        {
            try
            {
                return View(_Control.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        // GET: Controls/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                ////Control control = _Control.GetById(id);
                //if (control == null)
                //{
                //    return HttpNotFound();
                //}
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
           
        }

        // GET: Controls/Create
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

        // POST: Controls/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ControlDto control)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Control.Insert(control);

                    return RedirectToAction("Index");
                }


                return View(control);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET: Controls/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {

                ControlDto control = _Control.GetById(id);
                if (control == null)
                {
                    return HttpNotFound();
                }

                return View(control);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // POST: Controls/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ControlDto control)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Control.Update(control, control.ID);
                    return RedirectToAction("Index");
                }

                return View(control);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: Controls/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {

                ControlDto control = _Control.GetById(id);
                if (control == null)
                {
                    return HttpNotFound();
                }
                return View(control);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            }

        // POST: Controls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                _Control.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        
    }
}
