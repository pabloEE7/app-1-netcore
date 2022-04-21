using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_1.Helpers
{
    public class FiltroAction : IActionFilter

    {
        private  ILogger<FiltroAction> logger;

        public FiltroAction (ILogger<FiltroAction> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogError("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogError("OnActionExecuted");
        }
    }
}
