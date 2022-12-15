using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OfficeBusiness.Services;
using OfficeData.Repository;
using OfficeDL;
using OfficeDL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileAPI
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
            string connectionStr = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<Office_Context>(options => options.UseSqlServer(connectionStr));
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Office API",
                    Description = "office board management API",
                });


            });
            services.AddTransient<Profileservice, Profileservice>();
            services.AddTransient<ContactService, ContactService>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<TaskService,TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<CommentService, CommentService>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<MessageService, MessageService>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Office API"));
            app.UseHttpsRedirection();

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
