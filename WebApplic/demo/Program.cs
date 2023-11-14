using demo;
using demo.Utility.Route;
using demo.Utility.Swagger;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;




internal class Program
{
    private static void Main(string[] args)
    {
        var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("CfgFile/NLog.config").GetCurrentClassLogger();
        var builder = WebApplication.CreateBuilder(args);
        
        #region NLog配置
        //builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
        builder.Host.UseNLog();
        #endregion



        // 配置log4net    就会把之前的内置日志替换掉
        //builder.Logging.AddLog4Net("CfgFile/log4net.config"); 



        // Add services to the container.

        builder.Services.AddControllers(
        //    option =>   //在控制器里面配置 增加前缀
        //{
        //    option.Conventions.Insert(0, new RouteConvention(new RouteAttribute("api/")));
        //}
        );
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // 如果依赖包里面没有 就要 nuget: Swashbuckle.AspNetCore 去安装 Swashbuckle.AspNetCore这个依赖包
        #region Swagger的配置
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option => {
            #region 分版本的Swagger
            // 要启用swagger版本控制就要在api控制器或者方法上添加特性[ApiExplorerSettings(GroupName = "版本号")]
            // 
            typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                option.SwaggerDoc(version, new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = $"{version}:Api文档",
                    Version = version,
                    Description = $"通用版本的CoreApi{version}"
                })
            );
            #endregion

            #region 配置展示注释
            //{
            //    // xml文档的决定路径
            //    var file = Path.Combine(AppContext.BaseDirectory, "demo.xml");
            //    //true:显示控制器层注释
            //    option.IncludeXmlComments(file,true);
            //    // 对action的名称进行排序,如果有多个,就可以看见效果了
            //    option.OrderActionsBy(o => o.RelativePath);
            //}
            #endregion
            #region 扩展传入Token
            //{
            //    // 添加安全定义
            //    option.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme {
            //    Description = "请输入token,格式为 Bearer XXXX (注意中间必须有空格)",
            //    Name= "Authorization",
            //    In = ParameterLocation.
                
            //    })
            //}
            #endregion
        });
        #endregion

        builder.Services.AddCors(opt => {   //跨域的配置
            opt.AddDefaultPolicy(b =>
            {
                b.WithMethods(new string[] { "http://localhost:3000" }) // 配置信任域名发送请求
                 .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                //AllowAnyMethod(任意) 哪些请求类型 AllowAnyHeader(任意) 请求头  AllowCredentials(任意) 认证方式
                // 以上其中至少有一个不是any  否则程序报错
            });
        });

        builder.Services.AddScoped<Calculator>(); //注入Calculator 服务
                                                  // 配置 Calculator 类的实例化：Calculator 类的实例注册为单例服务。
                                                  // 这意味着在整个应用程序的生命周期内，只会创建一个 Calculator 实例。******
                                                  // 然后，当需要使用 Calculator 类的实例时，ASP.NET Core框架会负责在适当的时机创建它，并将其注入到需要它的地方，
                                                  // 例如在控制器的构造函数中，就像你之前提到的 CesCalculator 控制器的构造函数。
        builder.Services.AddScoped<OnlyCalculator>();

        // 但注册服务臃肿时 可以参考 119集
        // https://www.bilibili.com/video/BV1pK41137He?p=119&spm_id_from=pageDriver&vd_source=ed3a12d6e14be0749b8c8ab4b5033e86 



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            #region 使用Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options => {  //ui区分版本
                foreach (string version in typeof(ApiVersions).GetEnumNames()) {
                    options.SwaggerEndpoint($"/swagger/{version}/swagger.json",$"版本：{version}");
                }
            });
            #endregion
        }


        app.UseResponseCaching(); //启动服务器端响应缓存 这个时候CacheController类里的Get方法 启动的客户端缓存就会缓存到服务器端

        app.UseCors(); //使用跨域

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
