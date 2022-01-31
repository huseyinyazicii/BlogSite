using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWriterDal : EfEntityRepositoryBase<Writer, CodingUniverseBlogContext>, IWriterDal
    {
        public int NumberOfWriters()
        {
            using (var context = new CodingUniverseBlogContext())
            {
                var result = context.Writers.Count();
                return result;
            }
        }
    }
}
