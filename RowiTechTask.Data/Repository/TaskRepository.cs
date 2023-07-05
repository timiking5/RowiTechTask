namespace RowiTechTask.Data.Repository
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public void Update(Models.Task task)
        {
            // TODO - Fix TagTask updating
            task.Tags = null;
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
        }
    }
}
