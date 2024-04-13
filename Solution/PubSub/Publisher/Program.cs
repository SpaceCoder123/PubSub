using RepositoryLayer;

namespace Publisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<PublisherExceptionFilter>();
            builder.Services.AddSingleton<DbConnectionLayer>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors(options =>
            {
                options.WithOrigins("https://pubsubclient.azurewebsites.net", "http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            });

            app.UseExceptionHandler("/publisher/error");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.MapControllers();

            app.Run();
        }
    }
}
