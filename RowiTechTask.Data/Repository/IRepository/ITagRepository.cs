namespace RowiTechTask.Data.Repository.IRepository
{
    public interface ITagRepository : IRepository<Tag>
    {
        void Update(Tag tag);
    }
}
