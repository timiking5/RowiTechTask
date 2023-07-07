namespace RowiTechTask.Data.Repository.IRepository
{
    public interface ISolutionRepository : IRepository<Solution>
    {
        void Update(Solution solution);
    }
}
