namespace RowiTechTask.Data.Repository
{
    public class RemarkRepository : Repository<Remark>, IRemarkRepository
    {
        public RemarkRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public void Update(Remark remark)
        {
            _dbContext.Remarks.Update(remark);
            _dbContext.SaveChanges();
        }
    }
}
