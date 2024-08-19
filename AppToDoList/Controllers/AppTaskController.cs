using AppToDoList.Models;
using AppToDoList.Models.VMs;
using AppToDoList.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppToDoList.Controllers
{
    [Authorize]
    public class AppTaskController : Controller
    {
        private readonly IAppTaskService _appTaskService;
        private readonly UserManager<AppUser> _userManager;

        public AppTaskController(IAppTaskService appTaskService, UserManager<AppUser> userManager)
        {
            _appTaskService = appTaskService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //AppTaskListVM appTaskListVM = new AppTaskListVM()
            //{
            //    IsCompletedForDropDown = new List<SelectListItem>
            //    {
            //        new SelectListItem{Value="1",Text="All"},
            //        new SelectListItem{Value="2",Text="Completed"},
            //        new SelectListItem{Value="1",Text="Not Completed"}
            //    }
            //};

            var userId = _userManager.GetUserId(User);
            var tasks = await _appTaskService.GetUserAppTaskAsync(userId);
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AppTaskCreateVM model)
        {
            var userId = _userManager.GetUserId(User);
            var success = _appTaskService.AddAppTask(model, userId);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _appTaskService.GetAppTaskByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(AppTaskCreateVM model)
        {
            var userId = _userManager.GetUserId(User);
            var success = _appTaskService.UpdateAppTask(model, userId);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var success = _appTaskService.DeleteAppTask(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        

    }
}
