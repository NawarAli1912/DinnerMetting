using DinnerMetting.Api;
using DinnerMetting.Application;
using DinnerMetting.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services
            .AddApi()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
