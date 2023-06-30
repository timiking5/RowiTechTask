using Microsoft.AspNetCore.Mvc;
using RowiTechTask.Data.Repository.IRepository;

namespace RowiTechTask.Controllers
{
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
    }
}
