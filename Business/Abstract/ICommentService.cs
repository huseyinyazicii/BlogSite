using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService : IServiceRepository<Comment>
    {
        IDataResult<List<Comment>> GetByBlog(int blogId);
    }
}
