using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService : IServiceRepository<Category>
    {
        IDataResult<int> NumberOfCategories();
    }
}
