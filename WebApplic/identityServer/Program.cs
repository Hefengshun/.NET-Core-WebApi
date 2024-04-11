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

        //ע��һ������ ICustomJWTServiceΪ����   CustomHSJWTServiceΪ����ʵ��
        builder.Services.AddTransient<ICustomJWTService, CustomHSJWTService>();
        //��ȡ�����ļ��е�JWTTokenOptions
        builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));
        //����.NET Core��ʹ������ע��ϵͳ��һ�ַ�ʽ��ͨ��Configure����ֱ�ӽ�����ѡ��ע�ᵽ����ע�������С�
        //����ͨ������ע�루Dependency Injection����Ӧ�ó����е������ط�ֱ��ע��IOptions<JWTTokenOptions> ����ȡ�������ֵ
        //**** ������CustomHSJWTServiceʵ����ʹ��


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())  //�ж��Ƿ���ʽ����
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}

        app.UseHttpsRedirection();

        app.UseAuthentication();// ��Ȩ --- ��������ʱ�򣬰������д���token/session/cookies��������ȡ���û���Ϣ

        app.UseAuthorization(); // ��Ȩ --- �Ѿ��õ����û���Ϣ���ж��Ƿ���Է��ʵ�ǰ��Դ

        app.MapControllers();

        app.Run();
    }
}