using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Domain.Interfaces.Services;
using Domain.Entities;
using Domain.Service;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(_config.GetConnectionString("BaseDados")));
            services.AddControllers().AddNewtonsoftJson(); ;
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddAutoMapper(typeof(Startup));
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            services.AddScoped<IDepartamentRepository, DepartamentRepository>();
            services.AddScoped<IMovimentoManualRepository, MovimentoManualRepository>();
            services.AddScoped<IProdutoCosifRepository, ProdutoCosifRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddTransient<IDepartamentService, DepartamentService>();
            services.AddTransient<IMovimentoManualService, MovimentoManualService>();
            services.AddTransient<IProdutoCosifService, ProdutoCosifService>();
            services.AddTransient<IProdutoService, ProdutoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("MyPolicy");            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
