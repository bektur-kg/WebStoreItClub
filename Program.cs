using Microsoft.EntityFrameworkCore;
using Swagger.Repository;
using WebStore;
using WebStore.Services.Interfacies;

var builder = WebApplication.CreateBuilder(args);



// ����������� ������������
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��������� �������������� � �������������� JWT-�������
builder.Services.AddAuthentication().AddCookie("cookie");

// ���������� ����������� � ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ����������� �������������� � �����������
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
