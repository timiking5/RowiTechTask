﻿using Microsoft.AspNetCore.Authorization;
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
            model.Task.State = _unitOfWork.State.Get(x => x.StateName == "New");
            model.Task.StateId = model.Task.State.Id;
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
        public IActionResult Finish(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var taskFromDb = _unitOfWork.Task.Get(x => x.Id == id, "Tags,PayType,State");
            if (taskFromDb == null)
            {
                return NotFound();
            }

            var vm = ReturnVM();
            vm.Task = taskFromDb;
            vm.tagIds = taskFromDb.Tags.Select(x => x.Id).ToArray();
            
            return View(vm);
        }
        [HttpPost]
        public IActionResult Finish(TaskViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Task.Update(vm.Task);
                TempData["success"] = "Task finished successfully!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Finish", new { id = vm.Task.Id });
        }
        public TaskViewModel ReturnVM()
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
            IEnumerable<SelectListItem> stateList = _unitOfWork.State.GetAll().
                Where(x => x.StateName == "Failed" || x.StateName == "Finished").Select(u => new SelectListItem
            {
                Text = u.StateName,
                Value = u.Id.ToString()
            });
            return new TaskViewModel
            {
                PayTypes = payTypeList,
                Tags = tagList,
                States = stateList
            };
        }
    }
}
