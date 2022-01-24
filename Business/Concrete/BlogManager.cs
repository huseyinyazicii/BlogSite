using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        [ValidationAspect(typeof(BlogValidator))]
        public IResult Add(Blog blog)
        {
            _blogDal.Add(blog);
            return new SuccessResult();
        }

        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult();
        }

        public IDataResult<List<Blog>> GetAll()
        {
            var result = _blogDal.GetAll();
            return new SuccessDataResult<List<Blog>>(result);
        }

        public IDataResult<List<BlogDetailDto>> GetAllWithDetail(int number = 0)
        {
            List<BlogDetailDto> result = number == 0 
                                       ? _blogDal.GetBlogDetails() 
                                       : _blogDal.GetBlogDetails().Take(number).ToList();
            return new SuccessDataResult<List<BlogDetailDto>>(result);
        }

        public IDataResult<BlogDetailDto> GetBlogDetailsById(int blogId)
        {
            var result = _blogDal.GetBlogDetails(b => b.Id == blogId);
            return new SuccessDataResult<BlogDetailDto>(result[0]);
        }

        public IDataResult<List<BlogDetailDto>> GetByCategory(int categoryId)
        {
            var result = _blogDal.GetBlogDetails(b => b.CategoryId == categoryId);
            return new SuccessDataResult<List<BlogDetailDto>>(result);
        }

        public IDataResult<Blog> GetById(int id)
        {
            var result = _blogDal.Get(b => b.Id == id);
            return new SuccessDataResult<Blog>(result);
        }

        [ValidationAspect(typeof(BlogValidator))]
        public IResult Update(Blog blog)
        {
            _blogDal.Update(blog);
            return new SuccessResult();
        }
    }
}
