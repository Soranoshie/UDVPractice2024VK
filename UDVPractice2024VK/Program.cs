using log4net.Config;
using UDVPractice2024VK.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new Config(builder.Environment.IsDevelopment()));
builder.Services.RegisterModules();

XmlConfigurator.Configure(new FileInfo("log4net.config"));

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