using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_1.Helpers
{
    public class FiltroException : ExceptionFilterAttribute

    {
        public override void OnException(ExceptionContext context)
        {
            context.Exception.Message.ToString();
        }
    }
}
