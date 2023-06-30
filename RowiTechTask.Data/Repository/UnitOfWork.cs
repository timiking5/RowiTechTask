namespace RowiTechTask.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITaskRepository Task { get; private set; }

        public IUserRepository User { get; private set; }

        public IRemarkRepository Remark { get; private set; }

        public ITagRepository Tag { get; private set; }
        private ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Task = new TaskRepository(_dbContext);
            User = new UserRepository(_dbContext);
            Remark = new RemarkRepository(_dbContext);
            Tag = new TagRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
