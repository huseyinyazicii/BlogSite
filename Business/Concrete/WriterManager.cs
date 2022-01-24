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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        [ValidationAspect(typeof(WriterValidator))]
        public IResult Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult();
        }

        public IResult Delete(Writer writer)
        {
            _writerDal.Delete(writer);
            return new SuccessResult();
        }

        public IDataResult<List<Writer>> GetAll()
        {
            var result = _writerDal.GetAll();
            return new SuccessDataResult<List<Writer>>(result);
        }

        public IDataResult<Writer> GetById(int id)
        {
            var result = _writerDal.Get(w => w.Id == id);
            return new SuccessDataResult<Writer>(result);
        }

        [ValidationAspect(typeof(WriterValidator))]
        public IResult Update(Writer writer)
        {
            _writerDal.Update(writer);
            return new SuccessResult();
        }
    }
}
