namespace RowiTechTask.Data.Repository.IRepository
{
    public interface IStateRepository : IRepository<State>
    {
        void Update(State state);
    }
}
