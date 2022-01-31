using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, CodingUniverseBlogContext>, ICategoryDal
    {
        public int NumberOfCategories()
        {
            using (var context = new CodingUniverseBlogContext())
            {
                var result = context.Categories.Count();
                return result;
            }
        }
    }
}
