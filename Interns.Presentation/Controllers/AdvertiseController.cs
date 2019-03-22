using System;
using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Presentation.Models;
using Interns.Services.IService;

namespace Interns.Presentation.Controllers
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
            var getAll = advertiseService.GetAdvertises();

            AdvertisePagingViewModel model = new AdvertisePagingViewModel()
            {
                Advertises = getAll.OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize),
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
            ViewBag.Domain = domainService.GetDomains();
            ViewBag.User = userService.GetUsers().Where(e => e.Role.Name == "Company");
            ViewBag.SubDomain = subDomainService.GetSubDomains();

            return View();
        }
        [HttpPost]
        public ActionResult CreateAdvertise(Advertise advertise)
        {
            advertise.CreateDate = DateTime.Now;
            advertiseService.InsertAdvertise(advertise);

            return RedirectToAction("GetAllAdvertises");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditAdvertise(int id)
        {
            var us = advertiseService.GetAdvertise(id);
            return View(us);
        }

        [HttpPost]
        public ActionResult EditAdvertise(Advertise advertise)
        {
            advertiseService.UpdateAdvertise(advertise);
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