using Microsoft.Extensions.DependencyInjection;
using StorageWebApi.Data;
using StorageWebApi.Data.Repositories;
using StorageWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SWDbContext>();
builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoragesRepo, StoragesRepo>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddControllers();
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
