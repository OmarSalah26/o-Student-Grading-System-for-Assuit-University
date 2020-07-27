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
    public class EvaluationsController : Controller
    {
        private EvaluationLogic _Evaluation;
        public EvaluationsController()
        {
            _Evaluation = new EvaluationLogic();
        }

        // GET: Evaluations
        public ActionResult GetAll()
        {
            return View(_Evaluation.GetAll());
        }

        // GET: Evaluations/Details/6
        public ActionResult Details(long id)
        {
            try
            {

                EvaluationDto evaluation = _Evaluation.GetById(id);
                if (evaluation == null)
                {
                    return HttpNotFound();
                }
                return View(evaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET: Evaluations/Create
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

        // POST: Evaluations/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EvaluationDto evaluation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Evaluation.Update(evaluation, evaluation.id);
                    return RedirectToAction("GetAll");
                }

                return View(evaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET: Evaluations/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {

                EvaluationDto evaluation = _Evaluation.GetById(id);
                if (evaluation == null)
                {
                    return HttpNotFound();
                }
                return View(evaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // POST: Evaluations/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EvaluationDto evaluation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Evaluation.Update(evaluation, evaluation.id);
                    return RedirectToAction("Index");
                }
                return View(evaluation);

            }
            catch (Exception ex)
            {

                throw ex;
            }
                    }

        // GET: Evaluations/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {

                EvaluationDto evaluation = _Evaluation.GetById(id);
                if (evaluation == null)
                {
                    return HttpNotFound();
                }
                return View(evaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                _Evaluation.Delete(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw ex;
            }
                    }

       
    }
}
