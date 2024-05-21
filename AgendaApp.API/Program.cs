
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using AgendaApp.Domain.Services;
using AgendaApp.Infra.Data.Repositories;

namespace AgendaApp.API
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

            builder.Services.AddTransient<ITarefaDomainService, TarefaDomainService>();
            builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
