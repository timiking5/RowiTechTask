namespace RowiTechTask.Data.Repository.IRepository
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        void Update(Models.Task task);
    }
}
