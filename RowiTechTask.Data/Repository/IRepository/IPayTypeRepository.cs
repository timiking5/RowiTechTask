namespace RowiTechTask.Data.Repository.IRepository
{
    public interface IPayTypeRepository : IRepository<PayType>
    {
        void Update(PayType payType);
    }
}
