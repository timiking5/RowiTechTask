namespace RowiTechTask.Controllers
{
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
    }
}
