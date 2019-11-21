using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using DesafioGlobalTec.Helpers;
using DesafioGlobalTec.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace DesafioGlobalTec
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            

            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.ConfigureApplicationCookie(options => options.LoginPath = "/Users");

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Desafio GlobalTech",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new Contact
                        {
                            Name = "Fabio Lopes",
                            Url = "62 993978230"
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
               // app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/values");
            }

            app.UseStaticFiles();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStatusCodePages(async context => {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect("/api/error");
            });

           

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Desafio Globaltec");
            });
        }
    }
}
