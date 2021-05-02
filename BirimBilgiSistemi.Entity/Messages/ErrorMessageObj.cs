using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Messages
{
    public class ErrorMessageObj
    {
        public ErrorMessageCode Code { get; set; }
        public string Message { get; set; }
    }
}