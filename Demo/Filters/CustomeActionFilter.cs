using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Filters
{
    public class CustomeActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
