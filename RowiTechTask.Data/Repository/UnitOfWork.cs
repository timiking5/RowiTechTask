namespace RowiTechTask.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITaskRepository Task { get; private set; }

        public IUserRepository User { get; private set; }

        public IRemarkRepository Remark { get; private set; }

        public ITagRepository Tag { get; private set; }
        public IPayTypeRepository PayType { get; private set; }
        public IStateRepository State { get; private set; }
        public ISolutionRepository Solution { get; private set; }
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Task = new TaskRepository(_dbContext);
            User = new UserRepository(_dbContext);
            Remark = new RemarkRepository(_dbContext);
            Tag = new TagRepository(_dbContext);
            PayType = new PayTypeRepository(_dbContext);
            State = new StateRepository(_dbContext);
            Solution = new SolutionRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
