using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        [ValidationAspect(typeof(CommentValidator))]
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            var result = _commentDal.GetAll();
            return new SuccessDataResult<List<Comment>>(result);
        }

        public IDataResult<List<Comment>> GetByBlog(int blogId)
        {
            var result = _commentDal.GetAll(c => c.Status == true && c.BlogId == blogId);
            return new SuccessDataResult<List<Comment>>(result);
        }

        public IDataResult<Comment> GetById(int id)
        {
            var result = _commentDal.Get(c => c.Id == id);
            return new SuccessDataResult<Comment>(result);
        }

        [ValidationAspect(typeof(CommentValidator))]
        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult();
        }
    }
}
