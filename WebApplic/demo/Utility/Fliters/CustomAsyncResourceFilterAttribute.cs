using Microsoft.AspNetCore.Mvc.Filters;

namespace demo.Utility.Fliters
{
    /// <summary>
    /// 自定义 AsyncResourceFilter
    /// </summary>
    public class CustomAsyncResourceFilterAttribute : Attribute, IAsyncResourceFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task  OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Console.WriteLine("之前CustomAsyncResourceFilterAttribute.OnResourceExecutionAsync");

            await next.Invoke(); //执行被包裹的逻辑

            Console.WriteLine("之后CustomAsyncResourceFilterAttribute.OnResourceExecutionAsync");
        }
    }
}
