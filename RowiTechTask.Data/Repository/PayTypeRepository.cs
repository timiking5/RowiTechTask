namespace RowiTechTask.Data.Repository
{
    public class PayTypeRepository : Repository<PayType>, IPayTypeRepository
    {
        public PayTypeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public void Update(PayType payType)
        {
            _dbContext.PayTypes.Update(payType);
            _dbContext.SaveChanges();
        }
    }
}
