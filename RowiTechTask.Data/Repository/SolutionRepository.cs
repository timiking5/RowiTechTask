using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RowiTechTask.Data.Repository
{
    public class SolutionRepository : Repository<Solution>, ISolutionRepository
    {
        public SolutionRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        public void Update(Solution solution)
        {
            _dbContext.Solutions.Update(solution);
            _dbContext.SaveChanges();
        }
    }
}
