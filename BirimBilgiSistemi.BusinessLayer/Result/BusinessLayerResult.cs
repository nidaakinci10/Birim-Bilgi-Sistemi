using BirimBilgiSistemi.Entity.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.BusinessLayer.Result
{
    public class BusinessLayerResult<T> where T :class
    {
        //hata mesajları için oluşturuldu

        public List<ErrorMessageObj> Errors { get; set; }
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }

    }
}
