using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.Extensions.FileProviders;
using AlphaWebApp.Data;
using Microsoft.EntityFrameworkCore;
using AlphaWebApp.Repository;

namespace AlphaWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //definicion de la cadena de conexion a la base de datos
            services.AddDbContext<TiendaLibrosContext>(
                options => options.UseMySql("Server=localhost;Database=TiendaLibros;Uid=root;Pwd=root1234;")
            );
            
            services.AddControllersWithViews();

            //Estas linea es para que las paginas razor se actualicen sin necesidad de compilar la apliacion
            //la validacion es solo funcionara si esta en debug 
            #if DEBUG
            //se pueden agregar viewOptions para que las validaciones del cliente se activen o no
            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(options => 
            {
                options.HtmlHelperOptions.ClientValidationEnabled = true;
            });
            #endif

            //insercion de dependencias para que el controlador pueda ver el repository
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<LanguageRepository, LanguageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Sirve para activar el uso de archivos estaticos en la carpeta wwwroot
            app.UseStaticFiles();

            //Sirve para definir una nueva carpeta de archivos estaticos
            // app.UseStaticFiles(new StaticFileOptions()
            // {
            //     FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
            //     RequestPath="/MyStaticFiles"
            // });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
