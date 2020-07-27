using System;
using System.Web.Mvc;
using WebApplication4.Dto;
using WebApplication4.Logic;


namespace WebApplication4.Controllers
{
    public class RatesController : Controller
    {
        private RateLogic _Rate ;
        public RatesController()
        {
            _Rate = new RateLogic();
        }

        // GET: Rates
        public ActionResult GetAll()
        {
            try
            {
                return View(_Rate.GetAll());

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        // GET: Rates/Details/5
        public ActionResult Details(long id)
        {
            try
            {

                RateDto rate = _Rate.GetById(id);
                if (rate == null)
                {
                    return HttpNotFound();
                }
                return View(rate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET: Rates/Create
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

        // POST: Rates/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RateDto rate)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Rate.Insert(rate);
                    return RedirectToAction("GetAll");
                }

                return View(rate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Rates/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {

                RateDto rate = _Rate.GetById(id);
                if (rate == null)
                {
                    return HttpNotFound();
                }
                return View(rate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        // POST: Rates/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RateDto rate)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Rate.Update(rate, rate.id);
                    return RedirectToAction("GetAll");
                }
                return View(rate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
             
        }

        // GET: Rates/Delete/5
        public ActionResult Delete(long id)
        {
            try
            {

                RateDto rate = _Rate.GetById(id);
                if (rate == null)
                {
                    return HttpNotFound();
                }
                return View(rate);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {

                _Rate.Delete(id);
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

       
    }
}
