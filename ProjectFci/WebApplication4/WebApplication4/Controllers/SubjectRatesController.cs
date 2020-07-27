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
    public class SubjectRatesController : Controller
    {
        private SubjectRateLogic _subjectRatesLogic;

        public SubjectRatesController()
        {
            _subjectRatesLogic = new SubjectRateLogic();
        }
        // GET: SubjectRates
        public ActionResult Index()
        {
            try
            {
                return View(_subjectRatesLogic.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET: SubjectRates/Details/5
        public ActionResult Details(long RateId, string subjectcode)
        {
            try
            {

                SubjectRateDto subjectRate = _subjectRatesLogic.GetById(RateId, subjectcode);
                if (subjectRate == null)
                {
                    return HttpNotFound();
                }
                return View(subjectRate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: SubjectRates/Create
        public ActionResult Create()
        {
            try
            {
                SubjectLogic subjectLogic = new SubjectLogic();
                List<SubjectDto> subjects = subjectLogic.GetAll();
                ViewBag.Subjects = subjects;
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST: SubjectRates/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SubjectRateDto subjectRate)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _subjectRatesLogic.Insert(subjectRate);
                    return RedirectToAction("Index");
                }

                return View(subjectRate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: SubjectRates/Edit/5
        public ActionResult Edit(long RateId, string subjectcode)
        {
            try
            {

                SubjectRateDto subjectRate = _subjectRatesLogic.GetById(RateId, subjectcode);

                if (subjectRate == null)
                {
                    return HttpNotFound();
                }

                return View(subjectRate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: SubjectRates/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectRateDto subjectRate)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _subjectRatesLogic.Update(subjectRate, subjectRate.RateId, subjectRate.subjectcode);
                    return RedirectToAction("Index");
                }

                return View(subjectRate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: SubjectRates/Delete/5
        public ActionResult Delete(long RateId, string subjectcode)
        {
            try
            {

                SubjectRateDto subjectRate = _subjectRatesLogic.GetById(RateId, subjectcode);
                if (subjectRate == null)
                {
                    return HttpNotFound();
                }
                return View(subjectRate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: SubjectRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long RateId, string subjectcode)
        {
            try
            {

                _subjectRatesLogic.Delete(RateId, subjectcode);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
    }
}
