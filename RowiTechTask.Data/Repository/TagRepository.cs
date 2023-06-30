namespace RowiTechTask.Data.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public void Update(Tag tag)
        {
            _dbContext.Tags.Update(tag);
            _dbContext.SaveChanges();
        }
    }
}
