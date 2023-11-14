using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace demo.Utility.Fliters
{
    /// <summary>
    /// 自定义 AsyncResourceFilter
    /// </summary>
    public class CustomCacheAsyncResourceFilterAttribute : Attribute, IAsyncResourceFilter
    {
        /// <summary>
        /// 缓存区域
        /// </summary>
        private static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();
        public async Task  OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // 检查缓存 如果有直接返回
            string cacheKey = context.HttpContext.Request.Path; //Url地址
            if (CacheDictionary.ContainsKey(cacheKey))
            {
                object oResult = CacheDictionary[cacheKey]; //找到key 有缓存
                IActionResult result = oResult as IActionResult;
                context.Result = result; //请求处理的过程中的一个断路器 如果赋值了 就不完后执行了 如果没有赋值为null就继续执行
            }
            else
            {
                ResourceExecutedContext executedContext =  await next.Invoke(); //执行后返回的结果接收
                CacheDictionary[cacheKey] =  executedContext.Result;
            }
            

            Console.WriteLine("之后CustomAsyncResourceFilterAttribute.OnResourceExecutionAsync");
        }
    }
}
