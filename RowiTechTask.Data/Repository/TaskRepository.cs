namespace RowiTechTask.Data.Repository
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public void Update(Models.Task task)
        {
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
        }
    }
}
