global using Newtonsoft.Json;
global using Newtonsoft.Json.Converters;

using WeeekDotNetHelper.Service.Tasks;

namespace WeeekDotNetHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient("apiWeeek", c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["WeeekApi:ApiUrl"]);
            });

            builder.Services.AddScoped<ITasksService, TasksService>();
            builder.Services.AddScoped<IAppSettings, AppSettings>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
