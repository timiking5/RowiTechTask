global using RowiTechTask.Models;
global using Microsoft.AspNetCore.Mvc;
global using RowiTechTask.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using RowiTechTask.Utility;
using System.Data;

namespace RowiTechTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.AdminRole)]
    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var tagList = _unitOfWork.Tag.GetAll();
            return View(tagList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tag model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tag.Create(model);
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var tagFromDb = _unitOfWork.Tag.Get(x => x.Id == id);
            if (tagFromDb == null)
            {
                return NotFound();
            }
            return View(tagFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Tag model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tag.Update(model);
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Tag.Get(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var categoryFromDb = _unitOfWork.Tag.Get(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Tag.Delete(categoryFromDb);
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
