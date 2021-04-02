using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Banks.API.Extentions
{
    /// <summary>
    /// Consists of extention methods for ServiceCollection.
    /// </summary>
    public static class ServicesExtentions
    {
        /// <summary>
        /// Contains settings for Swagger.
        /// </summary>
        /// <param name="services">Instance of ServiceCollection.</param>
        public static void SwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Banks API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
            });
        }


        /// <summary>
        /// Sets the settings for authentication with access tokens.
        /// </summary>
        /// <param name="services">Instance of ServiceCollection.</param>
        /// <param name="configuration">Instance of Configuration.</param>
        public static void SetAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.SaveToken = true;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidIssuer = configuration["JwtToken:Issuer"],
                           ValidateAudience = true,
                           ValidAudience = configuration["JwtToken:Audience"],
                           ValidateLifetime = true,
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:Secret"])),
                           ValidateIssuerSigningKey = true,
                       };
                   });
        }
    }
}
