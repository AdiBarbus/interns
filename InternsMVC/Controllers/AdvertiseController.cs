using System.Web.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Entities;

namespace InternsMVC.Controllers
{
    public class AdvertiseController : Controller
    {
        private readonly IAdvertiseBll advertiseBll;
        private readonly IDomainBll domainBll;
        private readonly IUserBll userBll;
        private readonly ISubDomainBll subDomainBll;

        public AdvertiseController(IAdvertiseBll advertise, IDomainBll domain, IUserBll user, ISubDomainBll subDomain)
        {
            advertiseBll = advertise;
            domainBll = domain;
            userBll = user;
            subDomainBll = subDomain;
        }
        [HttpGet]
        public ActionResult GetAllAdvertises()
        {
            var getAll = advertiseBll.GetAllAdvertises();
            return View(getAll);
        }

        [HttpGet]
        public ActionResult CreateAdvertise()
        {
            ViewBag.Domain = domainBll.GetAllDomains();
            ViewBag.User = userBll.GetAllUsers();
            ViewBag.SubDomain = subDomainBll.GetAllSubDomains();
                        
            var viewModel = new Advertise()
            {
                CreateDate = System.DateTime.Now
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult CreateAdvertise(Advertise advertise)
        {
            advertiseBll.AddAdvertise(advertise);
            return RedirectToAction("GetAllSAdvertises");
        }

        [HttpGet]
        public ActionResult EditAdvertise(int id)
        {
            var us = advertiseBll.GetAdvertiseById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditAdvertise(Advertise advertise)
        {
            advertiseBll.EditAdvertise(advertise);
            return RedirectToAction("GetAllSAdvertises");
        }

        [HttpGet]
        public ActionResult DeleteSubDomain(int id)
        {
            advertiseBll.DeleteAdvertise(id);
            return RedirectToAction("GetAllSAdvertises");
        }
    }
}