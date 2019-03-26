using System.Linq;
using System.Web.Mvc;
using Interns.Core.Data;
using Interns.Services.Helpers;
using Interns.Services.IService;
using Interns.Services.Models.SelectFK;
using static System.String;

namespace Interns.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private int PageSize = 10;

        public UserController(IUserService user)
        {
            userService = user;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAllUsers(string stringSearch, string sortOrder, string currentFilter, int page = 1)
        {
            var getUsers = userService.GetUsers();

            SearchingAndPagingViewModel<User> model = new SearchingAndPagingViewModel<User>
            {
                Collection = getUsers.OrderBy(p => p.UserName).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems =
                        stringSearch == null ? getUsers.Count() :
                            getUsers.Count(s => s.UserName.Contains(stringSearch))
                },
                SortingOrder = IsNullOrEmpty(sortOrder) ? "name_desc" : "",
                SearchString = stringSearch
            };

            switch (sortOrder)
            {
                case "name_desc":
                    model.Collection = model.Collection.OrderByDescending(s => s.UserName);
                    break;
                default:
                    model.Collection = model.Collection.OrderBy(s => s.UserName);
                    break;
            }

            if (!IsNullOrEmpty(stringSearch))
            {
                model.Collection = getUsers.Where(s => s.UserName.Contains(stringSearch));
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditUser(int id)
        {
            SelectUsersRoleFk model = new SelectUsersRoleFk();
            model.User = userService.GetUser(id);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.UpdateUser(user);

                return RedirectToAction("GetAllUsers");
            }

            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(User user)
        {
            userService.DeleteUser(user);

            return RedirectToAction("GetAllUsers");
        }
    }
}