using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowiTechTask.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITaskRepository Task { get; }
        IUserRepository User { get; }
        IRemarkRepository Remark { get; }
        ITagRepository Tag { get; }
        IPayTypeRepository PayType { get; }
        IStateRepository State { get; }
        ISolutionRepository Solution { get; }
        void Save();
    }
}
