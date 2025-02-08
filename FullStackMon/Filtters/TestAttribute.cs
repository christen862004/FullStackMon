using Microsoft.AspNetCore.Mvc.Filters;

namespace FullStackMon.Filtters
{
    public class TestAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //
        }
    }
}
