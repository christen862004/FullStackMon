using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FullStackMon.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult=new ViewResult();
            viewResult.ViewName = "Error";//create shared
            //viewResult.ViewData[]=
            context.Result = viewResult;
        }
    }
}
