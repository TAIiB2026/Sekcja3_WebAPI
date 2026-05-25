
using Contracts;
using Services.Memory;

namespace WebAPI_Lab7
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

            //builder.Services.AddTransient<IPeopleService, PeopleService>();
            builder.Services.AddScoped<IPeopleService, PeopleService>();
            //builder.Services.AddSingleton<IPeopleService, PeopleService>();

            const string POLICY_NAME = "ourCORS";

            builder.Services.AddCors(opt => opt
                .AddPolicy(POLICY_NAME, policy => policy
                //.WithOrigins("http://localhost:58273")
                .AllowAnyOrigin()
                .AllowAnyMethod()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(POLICY_NAME);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
