using DinnerMetting.Api.Common.Errors;
using DinnerMetting.Application;
using DinnerMetting.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddSingleton<ProblemDetailsFactory, DinnerMettingProblemDetailsFactory>();
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
    app.MapControllers();

    app.Run();
}
