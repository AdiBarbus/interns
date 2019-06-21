using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;
using log4net;

namespace Interns.Presentation.Controllers
{
    public class QaController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QaController));

        private readonly IQaService qaService;
        private readonly ISubDomainService subDomainService;
        private readonly IAdvertiseService advertiseService;

        public QaController(IQaService qa, ISubDomainService subDomain, IAdvertiseService advertise)
        {
            qaService = qa;
            subDomainService = subDomain;
            advertiseService = advertise;
        }

        [HttpGet]
        public ActionResult Qas()
        {
            IEnumerable<Qa> qas = new List<Qa>();

            Log.Debug("Started getting all the QAs");
            try
            {
                qas = qaService.GetQas();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                throw;
            }

            return View(qas);
        }

        [HttpGet]
        public ActionResult SelectQasForeignKeys()
        {
            SelectQasFKs setForeignKeys = new SelectQasFKs();
            
            setForeignKeys.Advertises = advertiseService.GetAdvertises();
            setForeignKeys.SubDomains = subDomainService.GetSubDomains();

            return View(setForeignKeys);
        }

        [HttpPost]
        public ActionResult SelectQasForeignKeys(SelectQasFKs model)
        {
            Qa qa = new Qa();

            qa.AdvertiseId = model.SelectedAdvertiseId;
            qa.SubDomainId = model.SelectedSubDomainId;

            return RedirectToAction("CreateQa", new
            {
                qa.AdvertiseId,
                qa.SubDomainId
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateQa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateQa(Qa qa, int advertiseId, int subDomainId)
        {
            qa.AdvertiseId = advertiseId;
            qa.SubDomainId = subDomainId;

            Log.Debug("Creating new Q&A");
            try
            {
                qaService.InsertQa(qa);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                throw;
            }

            return RedirectToAction("Qas");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditQa(int id)
        {
            var editQa = qaService.GetQa(id);
            return View(editQa);
        }

        [HttpPost]
        public ActionResult EditQa(Qa qa)
        {
            Log.Debug($"Updating {qa.Question}");
            if (ModelState.IsValid)
            {
                try
                {
                    qaService.UpdateQa(qa);
                    Log.Info($"{qa.Question} was updated succesfully");
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                    throw;
                }
            }

            return RedirectToAction("Qas");
        }

        [HttpGet]
        public ActionResult DeleteQa(Qa qa)
        {
            Log.Debug($"Deleting {qa.Question}");

            try
            {
                qaService.DeleteQa(qa);
                Log.Info($"{qa.Question} was deleted succesfully");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                throw;
            }
            return RedirectToAction("Qas");
        }
    }
}