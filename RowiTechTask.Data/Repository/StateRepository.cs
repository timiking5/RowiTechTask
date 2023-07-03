namespace RowiTechTask.Data.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public void Update(State state)
        {
            _dbContext.States.Update(state);
            _dbContext.SaveChanges();
        }
    }
}
