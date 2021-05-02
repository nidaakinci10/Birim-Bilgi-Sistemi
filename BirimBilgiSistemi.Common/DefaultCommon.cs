using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Common
{
    public class DefaultCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            return "system";
        }
    }
}