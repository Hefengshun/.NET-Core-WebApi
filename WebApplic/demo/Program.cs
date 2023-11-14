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
        
        #region NLog����
        //builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
        builder.Host.UseNLog();
        #endregion



        // ����log4net    �ͻ��֮ǰ��������־�滻��
        //builder.Logging.AddLog4Net("CfgFile/log4net.config"); 



        // Add services to the container.

        builder.Services.AddControllers(
        //    option =>   //�ڿ������������� ����ǰ׺
        //{
        //    option.Conventions.Insert(0, new RouteConvention(new RouteAttribute("api/")));
        //}
        );
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // �������������û�� ��Ҫ nuget: Swashbuckle.AspNetCore ȥ��װ Swashbuckle.AspNetCore���������
        #region Swagger������
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option => {
            #region �ְ汾��Swagger
            // Ҫ����swagger�汾���ƾ�Ҫ��api���������߷������������[ApiExplorerSettings(GroupName = "�汾��")]
            // 
            typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
                option.SwaggerDoc(version, new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = $"{version}:Api�ĵ�",
                    Version = version,
                    Description = $"ͨ�ð汾��CoreApi{version}"
                })
            );
            #endregion

            #region ����չʾע��
            //{
            //    // xml�ĵ��ľ���·��
            //    var file = Path.Combine(AppContext.BaseDirectory, "demo.xml");
            //    //true:��ʾ��������ע��
            //    option.IncludeXmlComments(file,true);
            //    // ��action�����ƽ�������,����ж��,�Ϳ��Կ���Ч����
            //    option.OrderActionsBy(o => o.RelativePath);
            //}
            #endregion
            #region ��չ����Token
            //{
            //    // ��Ӱ�ȫ����
            //    option.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme {
            //    Description = "������token,��ʽΪ Bearer XXXX (ע���м�����пո�)",
            //    Name= "Authorization",
            //    In = ParameterLocation.
                
            //    })
            //}
            #endregion
        });
        #endregion

        builder.Services.AddCors(opt => {   //���������
            opt.AddDefaultPolicy(b =>
            {
                b.WithMethods(new string[] { "http://localhost:3000" }) // ��������������������
                 .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                //AllowAnyMethod(����) ��Щ�������� AllowAnyHeader(����) ����ͷ  AllowCredentials(����) ��֤��ʽ
                // ��������������һ������any  ������򱨴�
            });
        });

        builder.Services.AddScoped<Calculator>(); //ע��Calculator ����
                                                  // ���� Calculator ���ʵ������Calculator ���ʵ��ע��Ϊ��������
                                                  // ����ζ��������Ӧ�ó�������������ڣ�ֻ�ᴴ��һ�� Calculator ʵ����******
                                                  // Ȼ�󣬵���Ҫʹ�� Calculator ���ʵ��ʱ��ASP.NET Core��ܻḺ�����ʵ���ʱ����������������ע�뵽��Ҫ���ĵط���
                                                  // �����ڿ������Ĺ��캯���У�������֮ǰ�ᵽ�� CesCalculator �������Ĺ��캯����
        builder.Services.AddScoped<OnlyCalculator>();

        // ��ע�����ӷ��ʱ ���Բο� 119��
        // https://www.bilibili.com/video/BV1pK41137He?p=119&spm_id_from=pageDriver&vd_source=ed3a12d6e14be0749b8c8ab4b5033e86 



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            #region ʹ��Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options => {  //ui���ְ汾
                foreach (string version in typeof(ApiVersions).GetEnumNames()) {
                    options.SwaggerEndpoint($"/swagger/{version}/swagger.json",$"�汾��{version}");
                }
            });
            #endregion
        }


        app.UseResponseCaching(); //��������������Ӧ���� ���ʱ��CacheController�����Get���� �����Ŀͻ��˻���ͻỺ�浽��������

        app.UseCors(); //ʹ�ÿ���

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
