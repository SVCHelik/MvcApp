using Microsoft.EntityFrameworkCore;
using MvcApp.Models;    // ������������ ���� ������ ApplicationContext


var builder = WebApplication.CreateBuilder(args);


// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.MapDefaultControllerRoute();

app.Run();