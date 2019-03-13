using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InternsBusiness.Business;
using InternsDataAccessLayer.Entities;
using InternsMVC.Models;

namespace InternsMVC.Controllers
{
    public class AdvertiseController : Controller
    {
        private readonly IAdvertiseBll advertiseBll;
        private readonly IDomainBll domainBll;
        private readonly IUserBll userBll;
        private readonly ISubDomainBll subDomainBll;
        public int PageSize = 3;

        public AdvertiseController(IAdvertiseBll advertise, IDomainBll domain, IUserBll user, ISubDomainBll subDomain)
        {
            advertiseBll = advertise;
            domainBll = domain;
            userBll = user;
            subDomainBll = subDomain;
        }

        [HttpGet]
        [Route("advertise/GetAllAdvertises/{page}")]
        public ActionResult GetAllAdvertises(int page = 1)
        {
            var getAll = advertiseBll.GetAllAdvertises();

            AdvertisePagingViewModel model = new AdvertisePagingViewModel()
            {
                Advertises = getAll.Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = getAll.Count()
                }
            };

            return View(model);
            //return View(getAll);
        }

        [HttpGet]
        public ActionResult CreateAdvertise()
        {
            ViewBag.Domain = domainBll.GetAllDomains();
            ViewBag.User = userBll.GetAllUsers();
            ViewBag.SubDomain = subDomainBll.GetAllSubDomains();
                        
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdvertise(Advertise advertise)
        {
            advertise.CreateDate = DateTime.Now;
            advertiseBll.AddAdvertise(advertise);
            return RedirectToAction("GetAllAdvertises");
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
            return RedirectToAction("GetAllAdvertises");
        }

        [HttpGet]
        public ActionResult DeleteAdvertise(int id)
        {
            advertiseBll.DeleteAdvertise(id);
            return RedirectToAction("GetAllAdvertises");
        }
    }
}