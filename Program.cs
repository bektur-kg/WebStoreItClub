using Microsoft.EntityFrameworkCore;
using Swagger.Repository;
using WebStore;
using WebStore.Services.Interfacies;

var builder = WebApplication.CreateBuilder(args);



// Регистрация зависимостей
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Настройка аутентификации с использованием JWT-токенов
builder.Services.AddAuthentication().AddCookie("cookie");

// Добавление подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Подключение аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder.WithHeaders().AllowAnyHeader();
    builder.WithOrigins("http://localhost:5173/");
    builder.WithMethods().AllowAnyMethod();
});

app.Run();
