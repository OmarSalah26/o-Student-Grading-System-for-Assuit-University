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
    public class sectionsController : Controller
    {
        private SectionLogic _section;
        public sectionsController()
        {
            _section = new SectionLogic();
        }

        // GET: sections
        public ActionResult GetAll()
        {
            try
            {
                return View(_section.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: sections/Details/5
        public ActionResult Details(long id)
        {
            try
            {

                SectionDto section = _section.GetById(id);
                if (section == null)
                {
                    return HttpNotFound();
                }
                return View(section);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: sections/Create
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

        // POST: sections/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionDto section)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _section.Insert(section);
                    return RedirectToAction("GetAll");
                }

                return View(section);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: sections/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {

                SectionDto section = _section.GetById(id);
                if (section == null)
                {
                    return HttpNotFound();
                }
                return View(section);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // POST: sections/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SectionDto section)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _section.Update(section, section.id);
                    return RedirectToAction("Index");
                }
                return View(section);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: sections/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {

                SectionDto section = _section.GetById(id);
                if (section == null)
                {
                    return HttpNotFound();
                }
                return View(section);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                _section.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        
    }
}
