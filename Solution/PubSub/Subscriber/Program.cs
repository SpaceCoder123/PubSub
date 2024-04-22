using RepositoryLayer;
using RepositoryLayer.Interfaces;
using Services;
using Services.Interfaces;
using Subscriber.Filters;

namespace Subscriber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<SubscriberExceptionFilter>();
            builder.Services.AddTransient<DbConnectionLayer>();
            builder.Services.AddTransient<ISubscriberRepository, SubscriberRepository>();
            builder.Services.AddTransient<ISubscriberService, SubscriberService>();
            builder.Services.AddTransient<IAuditRepository, AuditRepository>();
            builder.Services.AddTransient<IAuditService, AuditService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseExceptionHandler("/subscriber/error");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.MapControllers();

            app.Run();
        }
    }
}