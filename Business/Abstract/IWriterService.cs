using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWriterService : IServiceRepository<Writer>
    {
        IDataResult<int> NumberOfWriters();
    }
}
