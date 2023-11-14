using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Security.Policy;

namespace demo.Utility.Fliters
{
    /// <summary>
    /// 自定义 ResourceFilter  IResourceFilter ResourceFilter的场景，天生就是为了缓存而生的
    /// </summary>
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter
    {
        /// <summary>
        /// 在XX资源之后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        void IResourceFilter.OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("CustomCacheResourceFilterAttribute.OnResourceExecuted");
        }
        /// <summary>
        /// 在XX资源之前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        void IResourceFilter.OnResourceExecuting(ResourceExecutingContext context)
        {

            Console.WriteLine("CustomCacheResourceFilterAttribute.OnResourceExecuting");
        }
        
    }
}
