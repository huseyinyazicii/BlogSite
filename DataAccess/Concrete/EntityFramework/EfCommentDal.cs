using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, CodingUniverseBlogContext>, ICommentDal
    {
        public int NumberOfComments()
        {
            using (var context = new CodingUniverseBlogContext())
            {
                var result = context.Comments.Count();
                return result;
            }
        }
    }
}
