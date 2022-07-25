using BooksAPIService.Exceptions;
using BooksAPIService.Models;
using BooksAPIService.Repositories;
using BooksAPIService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IBookTagsService, BookTagsService>();
builder.Services.AddTransient<IBookTagsRepository, BookTagsRepository>();

builder.Services.AddTransient<ITagService, TagService>();

builder.Services.AddTransient<IBooksService, BooksService>();
builder.Services.AddTransient<IBooksRepository, BooksRepository>();

builder.Services.AddDbContext<LibManagementDB>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
    options.UseMySql(builder.Configuration["db:MySqlDevEnv"], serverVersion);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AppGlobalExceptionHandler>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
