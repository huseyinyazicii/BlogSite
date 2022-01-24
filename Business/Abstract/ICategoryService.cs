using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService : IServiceRepository<Category>
    {
    }
}
