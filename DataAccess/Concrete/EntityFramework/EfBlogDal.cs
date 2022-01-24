using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, CodingUniverseBlogContext>, IBlogDal
    {
        public List<BlogDetailDto> GetBlogDetails(Expression<Func<BlogDetailDto, bool>> filter = null)
        {
            using (CodingUniverseBlogContext context = new CodingUniverseBlogContext())
            {
                var result = from b in context.Blogs  
                             join c in context.Categories
                             on b.CategoryId equals c.Id
                             join w in context.Writers
                             on b.WriterId equals w.Id
                             where b.Status == true
                             select new BlogDetailDto
                             {
                                 Id = b.Id,
                                 CategoryName = c.Name,
                                 WriterFullName = $"{w.FirstName} {w.LastName}",
                                 Title = b.Title,
                                 Content = b.Content,
                                 Image = b.Image,
                                 NumberOfComments = b.NumberOfComments,
                                 NumberOfLikes = b.NumberOfLikes,
                                 Date = b.Date,
                                 CategoryId = b.CategoryId
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}