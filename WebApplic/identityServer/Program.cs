using Zhaoxi.NET6Demo.IdentitySer.Utility;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //注册一个服务 ICustomJWTService为抽象   CustomHSJWTService为具体实现
        builder.Services.AddTransient<ICustomJWTService, CustomHSJWTService>();
        //读取配置文件中的JWTTokenOptions
        builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
        //这是.NET Core中使用依赖注入系统的一种方式，通过Configure方法直接将配置选项注册到依赖注入容器中。
        //可以通过依赖注入（Dependency Injection）在应用程序中的其他地方直接注入IOptions<JWTTokenOptions> 来获取配置项的值
        //**** 方便在CustomHSJWTService实现里使用


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())  //判断是否正式环境
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}

        app.UseHttpsRedirection();

        app.UseAuthentication();// 鉴权 --- 请求来的时候，把请求中带的token/session/cookies做解析，取出用户信息

        app.UseAuthorization(); // 授权 --- 已经得到了用户信息，判断是否可以访问当前资源

        app.MapControllers();

        app.Run();
    }
}