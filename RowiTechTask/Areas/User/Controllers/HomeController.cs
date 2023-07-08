using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RowiTechTask.Models;
using RowiTechTask.Models.ViewModels;
using RowiTechTask.Utility;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace RowiTechTask.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var taskList = _unitOfWork.Task.GetAll("PayType,State,Tags");
            foreach (var task in taskList)
            {
                bool fl = false;
                if (task.State.StateName == "Expired" || task.State.StateName == "Failed")
                {
                    continue;
                }
                if (task.ExpirationDate <= DateTime.Now)
                {
                    task.State = _unitOfWork.State.Get(x => x.StateName == "Expired");
                    fl = true;
                }
                
                if (fl)
                {
                    _unitOfWork.Task.Update(task);
                }
            }
            var temp = taskList.Where(x => x.State.StateName != "Expired" && x.State.StateName != "Failed");
            return View(temp);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var task = _unitOfWork.Task.Get(x => x.Id == id, "PayType,State,Tags");
            var solutions = _unitOfWork.Solution.GetAll("User,Remark").Where(x => x.TaskId == id).ToList();
            var userSolution = _unitOfWork.Solution.Get(x => x.TaskId == id && x.UserId == userId);
            var vm = new DetailsViewModel
            {
                Solutions = solutions,
                Task = task,
                UserSolution = userSolution == null ? new() : userSolution
            };

            if (task.State.StateName != "Expired" && task.State.StateName != "Failed" && task.State.StateName != "Finished")
            {
                return View(vm);
            }
            return View("OldTasks", vm);
        }
        [HttpPost, Authorize(Roles = "User,Admin")]
        public IActionResult Details(DetailsViewModel vm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var user = _unitOfWork.User.Get(x => x.Id == userId);
            vm.UserSolution.CreatedDate = DateTime.Now;
            vm.UserSolution.User = user;
            vm.UserSolution.UserId = userId;
            vm.UserSolution.TaskId = vm.Task.Id;
            if (ModelState.IsValid)
            {
                var userSolution = _unitOfWork.Solution.Get(x => x.TaskId == vm.Task.Id && x.UserId == userId);
                if (userSolution == null)
                {
                    TempData["success"] = "Solution successfully added";
                    _unitOfWork.Solution.Create(vm.UserSolution);
                }
                else
                {
                    TempData["success"] = "Solution successfully edited";
                    userSolution.Content = vm.UserSolution.Content;
                    _unitOfWork.Solution.Update(userSolution);
                }
                // return View(vm);
            }
            return Details(vm.Task.Id);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OldTasks(DetailsViewModel vm)
        {
            return View(vm);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult PostRemark(int solutionId, string remarkText)
        {
            var solution = _unitOfWork.Solution.Get(x => x.Id == solutionId, "Remark");
            if (solution == null)
            {
                return NotFound();
            }
            if (solution.Remark is null)
            {
                Remark remark = new()
                {
                    Description = remarkText
                };
                _unitOfWork.Remark.Create(remark);
                solution.Remark = remark;
                solution.RemarkId = remark.Id;
            }
            else
            {
                solution.Remark.Description = remarkText;
                _unitOfWork.Remark.Update(solution.Remark);
            }
            _unitOfWork.Solution.Update(solution);
            return Json(new { success = true, message = "Remark added successfully" });
        }
        #endregion
    }
}