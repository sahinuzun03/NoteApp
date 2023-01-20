using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NoteApp.Application.IoC;
using NoteApp.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<NoteDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
});

builder.Services.AddCors(_ =>
{
    _.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin => true);
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
