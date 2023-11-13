using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace demo.Utility.Route
{
    /// <summary>
    /// 全局路由前缀配置
    /// </summary>
    public class RouteConvention : IApplicationModelConvention
    {
        /// <summary>
        /// 定义一个路由前缀变量
        /// </summary>
        private readonly AttributeRouteModel _centeralPrefix;

        /// <summary>
        /// 调用时传入指定的路由前缀
        /// </summary>
        /// <param name="routeTemplateProvider"> 接收的前缀 </param>
        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            _centeralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        /// <summary>
        /// 接口的Apply方法 根据情况添加api路由前缀
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            foreach (var collection in application.Controllers) //循环所有控制器
            {
                var matchedSelectors = collection.Selectors.Where(x=>x.AttributeRouteModel !=null).ToArray();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        // 在 当前路由上添加一个路由前缀
                        selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_centeralPrefix, selectorModel.AttributeRouteModel);
                    }
                }
                // 没有标记 RoutAttribute 的 Controller
                var unmatchedSelectors = collection.Selectors.Where(x => x.AttributeRouteModel != null).ToArray();
                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        // 添加一个路由前缀
                        selectorModel.AttributeRouteModel = _centeralPrefix;
                    }
                }
            }
        }
    }
}
