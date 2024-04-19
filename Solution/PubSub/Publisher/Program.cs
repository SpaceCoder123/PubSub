using Microsoft.AspNetCore.Authentication.JwtBearer;
using RepositoryLayer;
using RepositoryLayer.Interfaces;
using Services;
using Services.Interfaces;
using System.Text;

namespace Publisher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Publisher API", Version = "v1" });
            });
            builder.Services.AddScoped<PublisherExceptionFilter>();
            builder.Services.AddSingleton<DbConnectionLayer>();
            builder.Services.AddTransient<IPublisherRepository, PublisherRepository>();
            builder.Services.AddTransient<IPublisherService, PublisherService>();
            builder.Services.AddTransient<IAuditRepository, AuditRepository>();
            builder.Services.AddTransient<IAuditService, AuditService>();

            builder.Services.AddAutoMapper(typeof(Program));

            #region Authentication 
            builder.Services.AddAuthentication(X =>
            {
                X.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                X.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                X.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidIssuer = "",
                ValidAudience = "",
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hey this is my key")),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            });
            #endregion

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors(options =>
            {
                options.WithOrigins("https://pubsubclient.azurewebsites.net", "http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            });
            app.UseExceptionHandler("/publisher/error");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
            });

            app.MapControllers();

            app.Run();
        }
    }
}