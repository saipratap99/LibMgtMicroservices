using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UsersAPIService.Exceptions;
using UsersAPIService.Models;
using UsersAPIService.Repositories;
using UsersAPIService.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
Console.WriteLine(builder.Configuration.GetSection("JWT:Issuer"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IUserTagsService, UserTagsService>();
builder.Services.AddTransient<IUserTagsRepository, UserTagsRepository>();

builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddTransient<ITagsService, TagsService>();
builder.Services.AddTransient<IUserBooksService, UserBooksService>();
builder.Services.AddTransient<IBooksService, BookService>();

builder.Services.AddDbContext<LibManagementDB>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
    options.UseMySql(builder.Configuration["db:MySqlDevEnv"], serverVersion);
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                                .GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Global Exception Handler
app.UseMiddleware<AppGlobalExceptionHandler>();

app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
