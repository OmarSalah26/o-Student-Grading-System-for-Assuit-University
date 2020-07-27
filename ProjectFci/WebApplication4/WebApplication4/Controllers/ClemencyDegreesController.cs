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
    public class ClemencyDegreesController : Controller
    {
        private readonly ClemencyDegreeLogic _IclemencyDegree;

        public ClemencyDegreesController()
        {
            _IclemencyDegree = new ClemencyDegreeLogic();
        }
        // GET: ClemencyDegrees
        public ActionResult GetAll()
        {
            try
            {

                return View(_IclemencyDegree.GetAll().ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: ClemencyDegrees/Details/5
        public ActionResult Details(long id)
        {
            try
            {
                ClemencyDegreeDto clemencyDegree = _IclemencyDegree.GetById(id);
                if (clemencyDegree == null)
                {
                    return HttpNotFound();
                }
                return View(clemencyDegree);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
           
        }

        // GET: ClemencyDegrees/Create
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

        // POST: ClemencyDegrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Describtion,Max,Min")] ClemencyDegreeDto clemencyDegree)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _IclemencyDegree.Insert(clemencyDegree);

                    return RedirectToAction("Index");
                }

                return View(clemencyDegree);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // GET: ClemencyDegrees/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {
                ClemencyDegreeDto clemencyDegree = _IclemencyDegree.GetById(id);
                if (clemencyDegree == null)
                {
                    return HttpNotFound();
                }
                return View(clemencyDegree);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
           
        }

        // POST: ClemencyDegrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Describtion,Max,Min")] ClemencyDegreeDto clemencyDegree)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _IclemencyDegree.Update(clemencyDegree, clemencyDegree.ID);
                    return RedirectToAction("Index");
                }
                return View(clemencyDegree);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET: ClemencyDegrees/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {
                ClemencyDegreeDto clemencyDegree = _IclemencyDegree.GetById(id);
                if (clemencyDegree == null)
                {
                    return HttpNotFound();
                }
                return View(clemencyDegree);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
           
        }

        // POST: ClemencyDegrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                _IclemencyDegree.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

      
    }
}
