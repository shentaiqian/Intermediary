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
        //    ////注册用户维护业务层
        //    //var basePath = AppContext.BaseDirectory;
        //    //var serviceDll = Path.Combine(basePath, "Intermediary.DaCheng.WebApi.dll");

        //    //if (!File.Exists(serviceDll))
        //    //{
        //    //    throw new Exception("找不到程序集");
        //    //}
        //    ////注册AOP拦截器
        //    //builder.RegisterType(typeof(NLogAop));
        //    //builder.RegisterAssemblyTypes(Assembly.LoadFrom(serviceDll))
        //    //    .AsImplementedInterfaces()
        //    //    .EnableInterfaceInterceptors()//开启切面，需要引入Autofac.Extras.DynamicProxy
        //    //    .InterceptedBy(typeof(NLogAop));//指定拦截器，可以指定多个
        //}

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<NLogFilterAttribute>();

            //添加Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Intermediary.DaCheng.WebApi",
                    Description = "基于.NET Core 3.0 的Api Swagger"
                });
                // 加载程序集的xml描述文档
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

            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-docs/{documentName}/swagger.json";
            });
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
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
