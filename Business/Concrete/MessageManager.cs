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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        [ValidationAspect(typeof(MessageValidator))]
        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult();
        }

        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult();
        }

        public IDataResult<List<Message>> GetAll()
        {
            var result = _messageDal.GetAll();
            return new SuccessDataResult<List<Message>>(result);
        }

        public IDataResult<Message> GetById(int id)
        {
            var result = _messageDal.Get(m => m.Id == id);
            return new SuccessDataResult<Message>(result);
        }

        [ValidationAspect(typeof(MessageValidator))]
        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult();
        }
    }
}
