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
    public class YearsController : Controller
    {
        private readonly YearLogic  _Iyear;

        public YearsController()
        {
             _Iyear= new YearLogic();
        }
        // GET: Years
        public ActionResult GetAll()
        {
            try
            {
                return View(_Iyear.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Years/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                YearDto year = _Iyear.GetById(id);
                if (year == null)
                {
                    return HttpNotFound();
                }
                return View(year);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        // GET: Years/Create
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

        // POST: Years/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( YearDto year)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Iyear.Insert(year);
                    return RedirectToAction("Index");
                }

                return View(year);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Years/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {

                YearDto year = _Iyear.GetById(id);

                if (year == null)
                {
                    return HttpNotFound();
                }
                return View(year);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Years/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(YearDto year)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Iyear.Update(year, year.id);

                    return RedirectToAction("Index");
                }
                return View(year);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Years/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {

                YearDto year = _Iyear.GetById(id);
                if (year == null)
                {
                    return HttpNotFound();
                }
                return View(year);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Years/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {

                _Iyear.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
    }
}
