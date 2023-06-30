namespace RowiTechTask.Data.Repository.IRepository
{
    public interface IRemarkRepository : IRepository<Remark>
    {
        void Update(Remark remark);
    }
}
