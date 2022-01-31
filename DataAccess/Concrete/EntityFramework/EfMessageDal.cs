using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, CodingUniverseBlogContext>, IMessageDal
    {
        public int NumberOfMessages()
        {
            using (var context = new CodingUniverseBlogContext())
            {
                var result = context.Messages.Count();
                return result;
            }
        }
    }
}
