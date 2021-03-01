using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Medicine.Extensions
{
    public static class SwaggerExtensions
    {
        public static void ConfigureSwaggerDocument(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocument(opt =>
            {
                opt.Title = "Medicine API";
            });
        }

        public  static void UseSwagger(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
