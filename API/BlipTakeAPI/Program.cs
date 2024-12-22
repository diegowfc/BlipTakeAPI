using Domain.Contracts.UseCases.GetAccountInformation;
using Domain.Contracts.UseCases.GetRepositoryInformation;
using Domain.Service.AccountServices;
using Domain.Service.RepositoryService;

namespace BlipTakeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IGetAccountInformationUseCase, AccountService>();
            builder.Services.AddScoped<IGetRepositoryInformationUseCase, RepositoryService>();

            builder.Services.AddAutoMapper(typeof(AccountMapper));
            builder.Services.AddAutoMapper(typeof(RepositoryMapper));


            var app = builder.Build();

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
