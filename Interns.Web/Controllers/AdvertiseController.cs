using System;
using System.Linq;
using System.Web.Mvc;
using Interns.Services.IService;
using Interns.Web.Models;
using Interns.Core.Data;

namespace Interns.Web.Controllers
{
    public class AdvertiseController : Controller
    {
        private readonly IAdvertiseService advertiseService;
        private readonly IDomainService domainService;
        private readonly IUserService userService;
        private readonly ISubDomainService subDomainService;
        public int PageSize = 3;

        public AdvertiseController(IAdvertiseService advertise, IDomainService domain, IUserService user, ISubDomainService subDomain)
        {
            advertiseService = advertise;
            domainService = domain;
            userService = user;
            subDomainService = subDomain;
        }

        [HttpGet]
        //[Route("advertise/GetAllAdvertises/{page}")]
        public ActionResult GetAllAdvertises(int page = 1)
        {
            var getAll = advertiseService.GetAllAdvertises();

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
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdvertise()
        {
            ViewBag.Domain = domainService.GetAllDomains();
            ViewBag.User = userService.GetAllUsers();
            ViewBag.SubDomain = subDomainService.GetAllSubDomains();
                        
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdvertise(Advertise advertise)
        {
            advertise.CreateDate = DateTime.Now;
            advertiseService.AddAdvertise(advertise);
            return RedirectToAction("GetAllAdvertises");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditAdvertise(int id)
        {
            var us = advertiseService.GetAdvertiseById(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditAdvertise(Advertise advertise)
        {
            advertiseService.EditAdvertise(advertise);
            return RedirectToAction("GetAllAdvertises");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAdvertise(Advertise advertise)
        {
            advertiseService.DeleteAdvertise(advertise);
            return RedirectToAction("GetAllAdvertises");
        }
    }
}