using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConsulMed
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
            builder.Services.AddDbContext<ConsulMed.Data.Contexto.ConsulMedContext>();

            //builder.Services.AddScoped<
            //    ConsulMed.Data.Interface.IAgendamentoConfiguracaoRepositorio,
            //    ConsulMed.Data.Repositorio.AgendamentoConfiguracaoRepositorio>();

            //builder.Services.AddScoped<
            //    ConsulMed.Data.Interface.IAgendamentoRepositorio,
            //    ConsulMed.Data.Repositorio.AgendamentoRepositorio>();

            builder.Services.AddScoped<
                ConsulMed.Data.Interface.IBeneficiarioRepositorio,
                ConsulMed.Data.Repositorio.BeneficiarioRepositorio>();

            builder.Services.AddScoped<
                ConsulMed.Data.Interface.IEspecialidadeRepositorio,
                ConsulMed.Data.Repositorio.EspecialidadeRepositorio>();

            builder.Services.AddScoped<
                ConsulMed.Data.Interface.IHospitalRepositorio,
                ConsulMed.Data.Repositorio.HospitalRepositorio>();

            builder.Services.AddScoped<
                ConsulMed.Data.Interface.IProfissionalRepositorio,
                ConsulMed.Data.Repositorio.ProfissionalRepositorio>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}