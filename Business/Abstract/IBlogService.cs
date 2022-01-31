using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService : IServiceRepository<Blog>
    {
        IDataResult<List<BlogDetailDto>> GetAllWithDetail(int number = 0);
        IDataResult<List<BlogDetailDto>> GetByCategory(int categoryId);
        IDataResult<BlogDetailDto> GetBlogDetailsById(int blogId);
        IDataResult<int> NumberOfBlogs();
    }
}