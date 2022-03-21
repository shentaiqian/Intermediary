using Intermediary.DaCheng.WebApi.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Intermediary.DaCheng.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="builder"></param>
        ///// <exception cref="Exception"></exception>
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    ////ע���û�ά��ҵ���
        //    //var basePath = AppContext.BaseDirectory;
        //    //var serviceDll = Path.Combine(basePath, "Intermediary.DaCheng.WebApi.dll");

        //    //if (!File.Exists(serviceDll))
        //    //{
        //    //    throw new Exception("�Ҳ�������");
        //    //}
        //    ////ע��AOP������
        //    //builder.RegisterType(typeof(NLogAop));
        //    //builder.RegisterAssemblyTypes(Assembly.LoadFrom(serviceDll))
        //    //    .AsImplementedInterfaces()
        //    //    .EnableInterfaceInterceptors()//�������棬��Ҫ����Autofac.Extras.DynamicProxy
        //    //    .InterceptedBy(typeof(NLogAop));//ָ��������������ָ�����
        //}

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<NLogFilterAttribute>();

            //���Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Intermediary.DaCheng.WebApi",
                    Description = "����.NET Core 3.0 ��Api Swagger"
                });
                // ���س��򼯵�xml�����ĵ�
                var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                var xmlFile = System.AppDomain.CurrentDomain.FriendlyName + ".xml";
                var xmlPath = Path.Combine(baseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //�����м����������Swagger��ΪJSON�ս��
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });
            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Api v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
