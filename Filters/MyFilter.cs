using Microsoft.AspNetCore.Mvc.Filters;

namespace test.Filters
{
    public class MyFilter : Attribute, IActionFilter

    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("on action executed");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("on action executing");
        }
    }
}
