using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMessageService : IServiceRepository<Message>
    {
        IDataResult<int> NumberOfMessages();
    }
}
