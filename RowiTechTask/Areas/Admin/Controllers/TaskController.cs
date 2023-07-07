using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using RowiTechTask.Models.ViewModels;
using RowiTechTask.Utility;
using System.Data;

namespace RowiTechTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.AdminRole)]
    public class TaskController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var taskList = _unitOfWork.Task.GetAll("PayType,State,Tags");
            return View(taskList);
        }
        public IActionResult UpSert(int? id)  // Update + Insert
        {
            IEnumerable<SelectListItem> tagList = _unitOfWork.Tag.GetAll().Select(u => new SelectListItem
            {
                Text = u.TagName,
                Value = u.Id.ToString()
            });
            IEnumerable<SelectListItem> payTypeList = _unitOfWork.PayType.GetAll().Select(u => new SelectListItem
            {
                Text = u.PayTypeName,
                Value = u.Id.ToString()
            });

            TaskViewModel vm = new() { PayTypes = payTypeList, Tags = tagList };
            if (id == 0 || id == null)
            {
                vm.Task = new Models.Task { Id = 0 };
                return View(vm);
            }
            // update
            Models.Task task = _unitOfWork.Task.Get(x => x.Id == id, "PayType,State,Tags");
            if (task == null)
            {
                return NotFound();
            }
            vm.tagIds = task.Tags.Select(x => x.Id).ToArray();
            vm.Task = task;
            return View(vm);
        }
        [HttpPost]
        public IActionResult UpSert(TaskViewModel model)
        {
            // TODO - Fix datetime.now issue
            model.Task.State = _unitOfWork.State.Get(x => x.StateName == "New");
            model.Task.StateId = model.Task.State.Id;
            // model.Task.CreatedDate = DateTime.Now;
            if (model.Task.ExpirationDate < DateTime.Now)
            {
                ModelState.AddModelError("Expiration date", "Expiration Date must be in future");
            }
            foreach (var id in model.tagIds)
            {
                model.Task.Tags.Add(_unitOfWork.Tag.Get(x => x.Id == id));
            }
            if (ModelState.IsValid)
            {
                if (model.Task.Id == 0)
                {
                    TempData["success"] = "Task successfully created";
                    _unitOfWork.Task.Create(model.Task);
                }
                else
                {
                    TempData["success"] = "Task successfully edited";
                    _unitOfWork.Task.Update(model.Task);
                }
                return RedirectToAction("Index");
            }
            IEnumerable<SelectListItem> tagList = _unitOfWork.Tag.GetAll().Select(u => new SelectListItem
            {
                Text = u.TagName,
                Value = u.Id.ToString()
            });
            IEnumerable<SelectListItem> payTypeList = _unitOfWork.PayType.GetAll().Select(u => new SelectListItem
            {
                Text = u.PayTypeName,
                Value = u.Id.ToString()
            });
            TaskViewModel vm = new() { PayTypes = payTypeList, Tags = tagList, Task = model.Task, tagIds = model.tagIds };
            return View(vm);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Task.Get(x => x.Id == id, "Tag,PayType,State");
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var categoryFromDb = _unitOfWork.Task.Get(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Task.Delete(categoryFromDb);
            TempData["success"] = "Task deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
