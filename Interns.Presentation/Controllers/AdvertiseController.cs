using System;
using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.DTO;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;
using static System.String;

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
        [AllowAnonymous]
        public ActionResult GetAllAdvertises(string stringSearch, string sortOrder, string currentFilter, int page = 1)
        {
            var getAdvertises = advertiseService.GetAdvertises();
            
            SearchingAndPagingViewModel<Advertise> model = new SearchingAndPagingViewModel<Advertise>
            {
                Collection = getAdvertises.OrderBy(p => p.Title).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                        stringSearch == null ? getAdvertises.Count() :
                            getAdvertises.Count(s => s.Title.Contains(stringSearch))
                },
                SortingOrder = IsNullOrEmpty(sortOrder) ? "end_date" : "",
                SearchString = stringSearch
            };

            switch (sortOrder)
            {
                case "end_date":
                    model.Collection = model.Collection.OrderByDescending(s => s.CreateDate);
                    break;
                default:  // Name ascending 
                    model.Collection = model.Collection.OrderBy(s => s.CreateDate);
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = getAdvertises.Where(s => s.Title.Contains(stringSearch));
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult SelectAdvertisesForeignKeys()
        {
            SelectAdvertisesFKs setForeignKeys = new SelectAdvertisesFKs();

            setForeignKeys.Users = userService.GetUsers().Where(e => e.Role.Name == "Company");
            setForeignKeys.Domains = domainService.GetDomains();
            setForeignKeys.SubDomains = subDomainService.GetSubDomains();

            return View(setForeignKeys);
        }

        [HttpPost]
        public ActionResult SelectAdvertisesForeignKeys(SelectAdvertisesFKs model)
        {
            Advertise advertise = new Advertise();

            advertise.DomainId = model.SelectedDomainId;
            advertise.UserId = model.SelectedUserId;
            advertise.SubDomainId = model.SelectedSubDomainId;

            return RedirectToAction("CreateAdvertise", new
            {
                advertise.DomainId,
                advertise.UserId,
                advertise.SubDomainId
            });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateAdvertise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdvertise(Advertise advertise, int domainId, int userId, int subDomainId)
        {
            advertise.CreateDate = DateTime.Now;
            advertise.DomainId = domainId;
            advertise.UserId = userId;
            advertise.SubDomainId = subDomainId;

            advertiseService.InsertAdvertise(advertise);

            return RedirectToAction("GetAllAdvertises");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditAdvertise(int id)
        {
            var advertises = advertiseService.GetAdvertise(id);
            return View(advertises);
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