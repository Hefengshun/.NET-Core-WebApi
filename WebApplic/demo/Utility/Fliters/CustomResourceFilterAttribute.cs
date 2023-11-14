using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace demo.Utility.Fliters
{
    /// <summary>
    /// 自定义 CustomCacheResourceFilterAttribute  扩展缓存
    /// </summary>
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter
    {
        /// <summary>
        /// 缓存区域
        /// </summary>
        private static Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();
        /// <summary>
        /// 在XX资源之后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        void IResourceFilter.OnResourceExecuted(ResourceExecutedContext context)
        {
            // 如果执行到这里，说明一定已经执行了 控制器的构造函数+一定执行了Api
            // 必然也已经得到了 计算的结果 就可以把结果保存到缓存里面
            string cacheKey = context.HttpContext.Request.Path; //Url地址
            CacheDictionary[cacheKey] = context.Result;

            Console.WriteLine("CustomResourceFilterAttribute.OnResourceExecuted");
        }
        /// <summary>
        /// 在XX资源之前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        void IResourceFilter.OnResourceExecuting(ResourceExecutingContext context)
        {
            // 检查缓存 如果有直接返回
            string cacheKey = context.HttpContext.Request.Path; //Url地址
            if (CacheDictionary.ContainsKey(cacheKey))
            {
                object oResult = CacheDictionary[cacheKey]; //找到key 有缓存
                IActionResult result = oResult as IActionResult;
                context.Result = result; //请求处理的过程中的一个断路器 如果赋值了 就不完后执行了 如果没有赋值为null就继续执行
            }
                // 就继续往后执行
            Console.WriteLine("CustomResourceFilterAttribute.OnResourceExecuting");
        }
    }
}
